using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Repository.IRepository;
using LanVar.Service.IService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanVar.Service.Service
{
    public class AuctionService : IAuctionService
    {
        private readonly IRoomRegistrationsRepository _roomRegistrationsRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IProductRepository _productRepository;

        public AuctionService(IRoomRegistrationsRepository roomRegistrationsRepository ,IUserRepository userRepository, IMapper mapper, IAuctionRepository auctionRepository, IProductRepository productRepository)
        {
            _roomRegistrationsRepository = roomRegistrationsRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _auctionRepository = auctionRepository;
            _productRepository = productRepository;

        }

        public async Task<AuctionDTOResponse> AcceptAuction(long id)
        {
            var existingAuction = await _auctionRepository.GetByIdAsync(id);
            if (existingAuction == null)
                throw new Exception($"Auction not existing!."); ;
            var product = await _productRepository.GetByIdAsync(existingAuction.product_id);
            if (product == null || !product.status)
            {
                throw new Exception($"Product is not available for auction!");
            }
            existingAuction.status = AuctionStatus.ACTIVE;
            var auction = _mapper.Map<Auction>(existingAuction);
            var acceptAuction = await _auctionRepository.UpdateAsync(auction);
            return _mapper.Map<AuctionDTOResponse>(acceptAuction);
        }

        public async Task<AuctionDTOResponse> CreateAuctionAsync(AuctionDTORequest auctionDto)
        {
            var checkPackage = await _userRepository.GetByIdAsync(auctionDto.User_id);
            if (checkPackage.package_id == 1)
                throw new Exception($"You should buy package to create Auction!."); ;
            var existingAuction = await _auctionRepository.GetByAuctionNameAsync(auctionDto.Auction_Name);
            if (existingAuction != null)
            {
                // Nếu có, bạn có thể xử lý ở đây, ví dụ như trả về null hoặc một giá trị đặc biệt để xác định rằng đã xảy ra trùng lặp
                // Trong ví dụ này, tôi sẽ trả về null
                throw new Exception($"Auction Name existing!."); ;
            }
            // Kiểm tra xem có phòng nào trùng Product_id không
            existingAuction = await _auctionRepository.GetByProductIdAsync(auctionDto.Product_id);
            if (existingAuction != null)
            {
                throw new Exception($"Auction Product existing!."); ;
            }
            var product = await _productRepository.GetByIdAsync(auctionDto.Product_id);
            if (product == null || !product.status)
            {
                throw new Exception($"Product is not available for auction!");
            }
            product.type = "auction";
            await _productRepository.Update(product);
            // Nếu không có phòng nào trùng Product_id, tiến hành tạo đấu giá
            auctionDto.Status = AuctionStatus.WAITING.ToString();
            var auction = _mapper.Map<Auction>(auctionDto);
            var createdAuction = await _auctionRepository.CreateAsync(auction);
            return _mapper.Map<AuctionDTOResponse>(createdAuction);
        }

        public async Task<bool> DeleteAuctionAsync(long id)
        {
            var auction = await _auctionRepository.GetByIdAsync(id);
            if (auction == null)
                return false;
            var product = await _productRepository.GetByIdAsync(auction.product_id);
            if (product != null)
            {
                product.status = false;
                await _productRepository.Update(product);
            }
            return await _auctionRepository.DeleteAsync(id);
        }

        public async Task<AuctionDTOResponse> EnterAuctionAsync(EnterAuctionDTORequest enterAuctionDTORequest)
        {
            // Kiểm tra xem đấu giá có tồn tại không
            var existingAuction = await _auctionRepository.GetByIdAsync(enterAuctionDTORequest.id);
            if (existingAuction == null)
            {
                throw new Exception($"Auction with ID {enterAuctionDTORequest.id} not found.");
            }

            // Kiểm tra mật khẩu
            if (existingAuction.password != enterAuctionDTORequest.Password)
            {
                throw new Exception("Incorrect password.");
            }

            // Kiểm tra xem người dùng đã đăng ký vào phòng đấu giá này chưa
            var roomRegistration = await _roomRegistrationsRepository.GetByFilterAsync(x => x.auction_id == existingAuction.id && x.status == RegisterStatus.ACTIVE && x.user_id == enterAuctionDTORequest.user_id);
            if (!roomRegistration.Any())
            {
                throw new Exception("You must register for this auction before entering.");
            }

            // Nếu mật khẩu đúng và người dùng đã đăng ký, trả về thông tin đấu giá
            return _mapper.Map<AuctionDTOResponse>(existingAuction);
        }


        public async Task<List<AuctionDTOResponse>> GetAllAuctionsAsync()
        {
            var auctions = await _auctionRepository.GetAllAsync();
            return _mapper.Map<List<AuctionDTOResponse>>(auctions);
        }

        public async Task<AuctionDTOResponse> GetAuctionByIdAsync(long id)
        {
            var auction = await _auctionRepository.GetByIdAsync(id);
            return _mapper.Map<AuctionDTOResponse>(auction);
        }

        public async Task<AuctionDTOResponse> UpdateAuctionAsync(long id, AuctionDTORequest auctionDto)
        {
            var existingAuction = await _auctionRepository.GetByIdAsync(id);
            if (existingAuction == null)
                throw new Exception($"Auction with ID {id} not found.");

            // Kiểm tra xem có đấu giá khác có cùng tên không
            var existingAuctionName = await _auctionRepository.GetByAuctionNameAsync(auctionDto.Auction_Name);
            if (existingAuctionName != null && existingAuctionName.id != id)
            {
                throw new Exception($"Auction Name existing!");
            }

            // Kiểm tra xem có đấu giá khác có cùng Product_id không
            var existingAuctionProduct = await _auctionRepository.GetByProductIdAsync(auctionDto.Product_id);
            if (existingAuctionProduct != null && existingAuctionProduct.id != id)
            {
                throw new Exception($"Auction Product existing!");
            }

            // Cập nhật thông tin của đấu giá
            existingAuction.auction_Name = auctionDto.Auction_Name;
            existingAuction.product_id = auctionDto.Product_id;
            // Cập nhật các trường khác nếu cần
            var auction = _mapper.Map(auctionDto, existingAuction);
            var updatedAuction = await _auctionRepository.UpdateAsync(auction);
            return _mapper.Map<AuctionDTOResponse>(updatedAuction);
        }

    }
}
