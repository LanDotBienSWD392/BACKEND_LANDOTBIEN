using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;

namespace LanVar.Service.Interface;

public interface ICartService
{
    Task<CartDTOResponse> AddItemToCart(CartDTORequest cartDtoRequest);
    Task<IEnumerable<CartDTOResponse>> GetAllItemInCartByUserId(); 
    Task<CartDTOResponse> UpdatedPackage(long id, SelectProductInCartDTORequest selected);
    Task<bool> DeleteItemInCart(long id);
}