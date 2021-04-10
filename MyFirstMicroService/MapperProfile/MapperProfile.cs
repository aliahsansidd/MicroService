using AutoMapper;
using EventBuss.Messages.Event;
using MyFirstMicroService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstMicroService.MapperProfile
{
    public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<MessageViewModel, MessageEvent>().ReverseMap();
		}
	}
}
