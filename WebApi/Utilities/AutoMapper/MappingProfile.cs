using System;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductDtoForInsertion>().ReverseMap();
            CreateMap<ProductDto, ProductDtoForInsertion>().ReverseMap();

            CreateMap<Product, ProductDtoForManupulation>().ReverseMap();


        }
    }
}

