using System;
using AutoMapper;
using LanVar.Core.Entity;
using LanVar.Service.DTO;
using LanVar.Service.DTO.response;

namespace LanVar.Service.AutoMapperProfile
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<UserRegisterRequest, User>().ReverseMap();
			CreateMap<LoginDTORequest, User>().ReverseMap();
			CreateMap<LoginDTOResponse, User>().ReverseMap();
		}
	}
}

