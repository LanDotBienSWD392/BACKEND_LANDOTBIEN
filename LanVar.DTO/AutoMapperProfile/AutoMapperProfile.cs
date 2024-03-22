using System;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.DTO.request;


namespace LanVar.DTO.AutoMapperProfile
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<CreateAccountDTORequest, User>().ReverseMap();
			CreateMap<LoginDTORequest, User>().ReverseMap();
			CreateMap<LoginDTOResponse, User>().ReverseMap();
			CreateMap<SearchProductDTORequest, Product>().ReverseMap();
			CreateMap<UpdateUserDTORequest, User>().ReverseMap();
			CreateMap<CreateProductDTORequest, Product>().ReverseMap();
			CreateMap<ProductDTOResponse, Product>().ReverseMap();
            CreateMap<AuctionDTOResponse, Auction>().ReverseMap();
            CreateMap<AuctionDTORequest, Auction>().ReverseMap();
            CreateMap<OrderItemDTORequest, OrderItem>().ReverseMap();
            CreateMap<OrderItemDTOResponse, OrderItem>().ReverseMap();
            CreateMap<CreateOrderDTORequest, Order>().ReverseMap();
            CreateMap<CreateOrderDTORespone, Order>().ReverseMap();
            CreateMap<CreateOrderDTORequest, Order>()
	            .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status ? OrderStatus.Confirmed : OrderStatus.Waiting));
            CreateMap<BillDTOResponse, Bill>().ReverseMap();
            CreateMap<BillDTORequest, Bill>().ReverseMap();
            CreateMap<BidDTORequest, Bid>().ReverseMap();
            CreateMap<BidDTOResponse, Bid>().ReverseMap();
            CreateMap<UserDTOResponse, User>().ReverseMap();
            CreateMap<RoomRegistrationsDTORequest, RoomRegistrations>().ReverseMap();
            CreateMap<RoomRegistrationsDTOResponse, RoomRegistrations>().ReverseMap();

            CreateMap<RoomRegistrations, RoomRegistrationsDTOResponse>();
            CreateMap<BuyPackageDTORequest, Package>().ReverseMap();
            CreateMap<UserPackageDTORequest, User_Package>().ReverseMap();
		}
	}
}

