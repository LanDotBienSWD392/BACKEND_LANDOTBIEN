using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;

namespace LanVar.Service.Interface;

public interface IOrderItemService
{
    Task<OrderItemDTOResponse> AddItemToCart(OrderItemDTORequest orderItemDtoRequest);
    Task<IEnumerable<OrderItemDTOResponse>> GetAllItemInCartByUserId(); 
    Task<IEnumerable<OrderItemDTOResponse>> SelectItem(long id, SelectProductInCartDTORequest selected);
    Task<bool> DeleteItemInCart(long id);
}