using AutoMapper;
using Minimal_API.Models;
using Minimal_API.Models.DTOs;

namespace Minimal_API
{
	public class MappingConfig : Profile
	{
        public MappingConfig()
        {
			CreateMap<Book, BookDTO>().ReverseMap();
			CreateMap<Book, BookCreateDTO>().ReverseMap();
			CreateMap<Book, BookUpdateDTO>().ReverseMap();
		}
	}
}
