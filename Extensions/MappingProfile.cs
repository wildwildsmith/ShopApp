using AutoMapper;
using ShopApp.Entities.DTO.OrderItemsDto;
using ShopApp.Entities.DTO.OrdersDto;
using ShopApp.Entities.DTO.ProductsDto;
using ShopApp.Entities.DTO.UserDto;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>();

            CreateMap<Order, OrderDto>()
                .ForMember(o => o.Id, ex => ex.MapFrom(i => i.Id)).ReverseMap();
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<OrderForUpdateDto, Order>();

            CreateMap<OrderItem, OrderItemDto>();

            CreateMap<UserForRegistrationDto, User>()
                .ForSourceMember(u => u.ConfirmPassword, opt => opt.DoNotValidate());
        }
    }
}
