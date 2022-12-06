using AutoMapper;
using Domain.Entity;

namespace Application.CQRS.Book.Dto
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<BookDto, Books>().ReverseMap();
            CreateMap<BookUpdateCommand, Books>().ReverseMap();
            CreateMap<BookAuthorDto, Writers>().ReverseMap();
            CreateMap<BookCreateCommand, Books>().ReverseMap();
        }
    }
}
