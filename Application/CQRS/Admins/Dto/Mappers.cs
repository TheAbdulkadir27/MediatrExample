using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CQRS.Admins.Dto
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<AdminDto, Admin>().ReverseMap();
            CreateMap<AdminCreateCommand, Admin>().ReverseMap();
            CreateMap<AdminUpdateCommand, Admin>().ReverseMap();
        }
    }
}
