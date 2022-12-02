using AutoMapper;
using Domain.Entity;

namespace Application.CQRS.Categorys.Dto
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
