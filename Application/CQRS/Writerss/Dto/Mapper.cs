using Application.CQRS.Book.Dto;
using AutoMapper;
using Domain.Entity;

namespace Application.CQRS.Writerss.Dto
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<WritersDto, Writers>().ReverseMap();
            CreateMap<BookAuthorDto, BookAuthors>().ReverseMap();
        }
    }
}
