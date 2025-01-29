using AutoMapper;
using ProductMicroservice.Application.DTOs;
using ProductMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Application.Mappings
{
    public class ProductProfile:Profile
    {

        public ProductProfile()
        {


            CreateMap<ProductDto,Product>().ReverseMap();
            CreateMap<CreateProductDto,Product>().ReverseMap();
            CreateMap<UpdateProductDto,Product>().ReverseMap();

        }
    }
}
