﻿using System;
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
        }
	}
}

