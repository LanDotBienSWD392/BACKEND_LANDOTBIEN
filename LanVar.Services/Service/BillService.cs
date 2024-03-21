using System.Net;
using System.Runtime.Serialization;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using System.Linq;
using Tools.Tools;

namespace LanVar.Service.Service
{
    public class BillService : IBillService
    {
        private readonly IGenericRepository<Bill> _genericBillRepository;
        private readonly IBillRepository _billRepository;
        private readonly IGenericRepository<OrderItem> _genericOrderItemRepository;
        private readonly IUserService _userService;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IGenericRepository<Product> _genericProductRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<User> _genericUserRepository;

        public BillService(IGenericRepository<Bill> genericBillRepository,
            IBillRepository billRepository,
            IOrderItemRepository genericOrderItemRepository,
            IUserService userService,
            IOrderItemRepository orderItemRepository, 
            IGenericRepository<Product> genericProductRepository,
            IOrderRepository orderRepository,
            IMapper mapper,
            IGenericRepository<User> genericUserRepository)
        {
            _genericBillRepository = genericBillRepository;
            _billRepository = billRepository;
            _genericOrderItemRepository = genericOrderItemRepository;
            _userService = userService;
            _orderItemRepository = orderItemRepository;
            _genericProductRepository = genericProductRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
            _genericUserRepository = genericUserRepository;
        }

        public async Task<BillDTOResponse> CreateBill(BillDTORequest orderCode)
        {
            string userId = _userService.GetUserID();

            // Retrieve the order by order code
            var order = await _orderRepository.GetByOrderCode(orderCode.orderCode);
            if (order == null)
            {
                throw new CustomException.InvalidDataException("cc","Order not found.");
            }

            // Calculate the total price of the order
            double totalPrice = await _orderRepository.Sum(orderCode.orderCode);

            // Map the BillDTORequest to a Bill entity
            var bill = _mapper.Map<Bill>(orderCode);
            bill.user_id = long.Parse(userId);
            bill.orderCode = orderCode.orderCode;
            bill.paymentUrl = "";
            bill.payment_Method = "VNPAY";
            bill.total_Price = totalPrice;
            bill.status = false;

            // Add the bill to the repository
            await _genericBillRepository.Add(bill);

            // Delete order items related to the bill
            await _orderItemRepository.DeleteOrderByOrderCode(orderCode.orderCode);
            var user = await _genericUserRepository.GetByIdAsync(long.Parse(userId));
            var userName = user.username;

            // Map the bill entity to BillDTOResponse and return
            BillDTOResponse billDtoResponse = _mapper.Map<BillDTOResponse>(bill);
            billDtoResponse.user_id = userName;
            return billDtoResponse;
        }
    }
}
