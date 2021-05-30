using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FirstWebApp.Models;
using FirstWebApp.Dtos;

namespace FirstWebApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Id, act => act.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.Id, act => act.Ignore());
        }
    }
}