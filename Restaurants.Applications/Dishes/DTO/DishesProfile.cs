using System;
using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Applications.Dishes.DTO;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDto>();
    }
}
