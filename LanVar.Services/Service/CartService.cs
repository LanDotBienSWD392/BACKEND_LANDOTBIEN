using System.Net;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Core.Interfaces;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using Tools.Tools;

namespace LanVar.Service.Service;

public class CartService : ICartService
{
    private readonly IGenericRepository<Cart> _genericCartRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IUserService _userService;
    private readonly IGenericRepository<Product> _genericProductRepository;
    private readonly IMapper _mapper;
    public CartService(IGenericRepository<Cart> genericCartRepository,
        IUserService userService,
        IMapper mapper,
        IGenericRepository<Product> genericProductRepository,
        ICartRepository cartRepository
        )
    {
        _genericCartRepository = genericCartRepository;
        _userService = userService;
        _mapper = mapper;
        _genericProductRepository = genericProductRepository;
        _cartRepository = cartRepository;
    }
    public async Task<CartDTOResponse> AddItemToCart(CartDTORequest cartDtoRequest)
    {
        var cart = _mapper.Map<Cart>(cartDtoRequest);
        string userId = _userService.GetUserID();
        cart.User_id = long.Parse(userId);
        cart.isSelected = false;
        Cart addedProduct = await _genericCartRepository.Add(cart);
        CartDTOResponse cartDtoResponse = _mapper.Map<CartDTOResponse>(addedProduct);
        Product productInfo = await _genericProductRepository.GetByIdAsync(cart.Product_id);
        cartDtoResponse.Product = productInfo.Product_Name;
        return cartDtoResponse;
    }

    public async Task<IEnumerable<CartDTOResponse>> GetAllItemInCartByUserId()
    {
        string id = _userService.GetUserID();
        IEnumerable<Cart> carts = await _cartRepository.GetByUserIdAsync(long.Parse(id));

        if (carts != null && carts.Any())
        {
            List<CartDTOResponse> cartResponses = new List<CartDTOResponse>();

            foreach (var cart in carts)
            {
                Product productInfo = await _genericProductRepository.GetByIdAsync(cart.Product_id);
                CartDTOResponse cartDtoResponse = _mapper.Map<CartDTOResponse>(cart);
                cartDtoResponse.Product = productInfo.Product_Name;
                cartResponses.Add(cartDtoResponse);
            }

            return cartResponses; // Return the list of responses
        }
        else
        {
            return Enumerable.Empty<CartDTOResponse>(); // Or return an empty collection if no carts are found
        }
    }

    public async Task<CartDTOResponse> UpdatedPackage(long id, SelectProductInCartDTORequest selected)
    {
        var existingProduct = await _genericCartRepository.GetById(id);
        string userId = _userService.GetUserID();
        IEnumerable<Cart> carts = await _cartRepository.GetByUserIdAsync(long.Parse(userId));
        if (existingProduct == null)
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Item not found");
        }
        bool productExistsInCart = carts.Any(cart => cart.Product_id == existingProduct.Product_id); 

        if (!productExistsInCart)
        {
            
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Item not found in the user's cart");
        }

        existingProduct.isSelected = selected.isSelected;
        var updatedProduct = await _genericCartRepository.Update(existingProduct);

        // Map the updated Cart object to a CartDTOResponse object
        var updatedCartDtoResponse = _mapper.Map<CartDTOResponse>(updatedProduct);

        return updatedCartDtoResponse;
    }

    public async Task<bool> DeleteItemInCart(long id)
    {
        var existingProduct = await _genericCartRepository.GetById(id);
        string userId = _userService.GetUserID();
        IEnumerable<Cart> carts = await _cartRepository.GetByUserIdAsync(long.Parse(userId));

        if (existingProduct == null)
        {
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Item not found");
        }

        
        bool productExistsInCart = carts.Any(cart => cart.Product_id == existingProduct.Product_id); 

        if (!productExistsInCart)
        {
            
            throw new CustomException.InvalidDataException(HttpStatusCode.NotFound.ToString(), "Item not found in the user's cart");
        }

        await _genericCartRepository.Delete(id);
        return true;
    }
}