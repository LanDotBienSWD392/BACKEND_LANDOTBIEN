using System.Net;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using LanVar.Services.Service;
using Tools.Tools;

namespace LanVar.Service.Service;

public class OrderItemService : IOrderItemService
{
    private readonly IGenericRepository<OrderItem> _genericOrderItemRepository;
    private readonly IGenericRepository<User> _genericUserRepository;
    private readonly IGenericRepository<Product> _genericProductRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public OrderItemService(IGenericRepository<OrderItem> genericOrderItemRepository,
        IOrderItemRepository orderItemRepository,
            IUserService userService,
        IMapper mapper,
        IGenericRepository<User> genericUserRepository,
        IGenericRepository<Product> genericProductRepository)
    {
        _genericOrderItemRepository = genericOrderItemRepository;
        _orderItemRepository = orderItemRepository;
        _userService = userService;
        _mapper = mapper;
        _genericUserRepository = genericUserRepository;
        _genericProductRepository = genericProductRepository;

    }
    public async Task<OrderItemDTOResponse> AddItemToCart(OrderItemDTORequest orderItemDtoRequest)
    {
        string id = _userService.GetUserID();
        var user1 = await _genericUserRepository.GetById(long.Parse(id));
        var user = _mapper.Map<OrderItem>(orderItemDtoRequest);
        var produtcName = await _genericProductRepository.GetById(orderItemDtoRequest.product_id);
        user.user_id = long.Parse(id);
        user.isSelected = false;
        user.hidden = false;
        await _orderItemRepository.Add(user);
        var orderItemDTOResponse = _mapper.Map<OrderItemDTOResponse>(user);
        orderItemDTOResponse.product_name = produtcName.product_Name;
        orderItemDTOResponse.user_name = user1.name;
        return orderItemDTOResponse;
    }

    public async Task<IEnumerable<OrderItemDTOResponse>> GetAllItemInCartByUserId()
    {
        string id = _userService.GetUserID();
        IEnumerable<OrderItem> orderItems = await _orderItemRepository.GetAllByUserIdAsync(long.Parse(id));
        var userName = await _genericUserRepository.GetById(long.Parse(id));
        //IEnumerable<Product> products = await _genericProductRepository.GetAllAsync();
        //var orderItemDtoResponses = _mapper.Map<IEnumerable<OrderItemDTOResponse>>(orderItems);
        List<OrderItemDTOResponse> orderItemResponse = new List<OrderItemDTOResponse>();
 
        foreach (var orderItem in orderItems)
        {
            Product productInfor = await _genericProductRepository.GetById(orderItem.product_id);
            OrderItemDTOResponse orderItemDtoResponse = _mapper.Map<OrderItemDTOResponse>(orderItem);
            
            orderItemDtoResponse.product_name = productInfor.product_Name;
            orderItemDtoResponse.user_name = userName.name;
            orderItemDtoResponse.price = productInfor.product_Price;
            orderItemDtoResponse.desciption = productInfor.product_Description;
            orderItemDtoResponse.image = productInfor.image;
            orderItemResponse.Add(orderItemDtoResponse);
        }
        return orderItemResponse;
    }


    public async Task<IEnumerable<OrderItemDTOResponse>> SelectItem(long id, SelectProductInCartDTORequest selected)
    {
        string userId = _userService.GetUserID();
    
        // Lấy thông tin đơn hàng dựa trên id
        OrderItem orderItem1 = await _genericOrderItemRepository.GetById(id);
    
        // Kiểm tra xem đơn hàng có tồn tại không
        if (orderItem1 == null)
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Order not found");
        }
    
        // Kiểm tra xem đơn hàng có thuộc về người dùng hiện tại không
        if (orderItem1.user_id != long.Parse(userId))
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(), "Access denied");
        }

        // Lấy danh sách các mục đơn hàng của người dùng hiện tại
        var orderItems = await _orderItemRepository.GetAllByUserIdAsync(long.Parse(userId));
    
        // Kiểm tra xem có mục đơn hàng nào không
        if (!orderItems.Any())
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(), "Order error");
        }

        // Lấy thông tin người dùng từ genericUserRepository
        var userName = await _genericUserRepository.GetById(long.Parse(userId));
    
        // Tạo danh sách các đối tượng DTO dựa trên thông tin đơn hàng
        List<OrderItemDTOResponse> orderItemResponse = new List<OrderItemDTOResponse>();
 
        foreach (var orderItem in orderItems)
        {
            Product productInfor = await _genericProductRepository.GetById(orderItem.product_id);
            OrderItemDTOResponse orderItemDtoResponse = _mapper.Map<OrderItemDTOResponse>(orderItem);
            orderItemDtoResponse.product_name = productInfor.product_Name;
            orderItemDtoResponse.user_name = userName.name;
            orderItemDtoResponse.isSelected = selected.isSelected;
            orderItemResponse.Add(orderItemDtoResponse);
            

        }

        orderItem1.isSelected = selected.isSelected;
        await _genericOrderItemRepository.Update(orderItem1);
        

        return orderItemResponse;
    }



    public async Task<bool> DeleteItemInCart(long id)
    {
        string userId = _userService.GetUserID();
        var orderItems = await _orderItemRepository.GetAllByUserIdAsync(long.Parse(userId));
        OrderItem orderItem1 = await _genericOrderItemRepository.GetById(id);
    
        // Kiểm tra xem đơn hàng có tồn tại không
        if (orderItem1 == null)
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Order not found");
        }
    
        // Kiểm tra xem đơn hàng có thuộc về người dùng hiện tại không
        if (orderItem1.user_id != long.Parse(userId))
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(), "Access denied");
        }
        if (!orderItems.Any())
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.BadRequest.ToString(),$"Order error");
        }

        orderItem1.hidden = true;
        await _genericOrderItemRepository.Update(orderItem1);
        return true;
    }
}