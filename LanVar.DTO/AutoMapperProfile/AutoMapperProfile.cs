using System;
using AutoMapper;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;


namespace LanVar.DTO.AutoMapperProfile
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<UserRegisterRequest, User>().ReverseMap();
			CreateMap<LoginDTORequest, User>().ReverseMap();
			CreateMap<LoginDTOResponse, User>().ReverseMap();
			CreateMap<SearchProductDTORequest, Product>().ReverseMap();
			CreateMap<UpdateUserDTORequest, User>().ReverseMap();
		}
	}
}

