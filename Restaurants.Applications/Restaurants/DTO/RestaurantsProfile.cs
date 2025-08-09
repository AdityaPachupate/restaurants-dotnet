using AutoMapper;
using Restaurants.Applications.Restaurants.Commands.CreateRestaurants;
using Restaurants.Applications.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Applications.Restaurants.DTO;

public class RestaurantsProfile : Profile
{
    public RestaurantsProfile()
    {
        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(destination => destination.City, opt => opt.MapFrom(source => source.Address == null ? null : source.Address.City))
            .ForMember(dst => dst.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(dst => dst.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(dst => dst.Dishes, opt => opt.MapFrom(src => src.Dishes == null ? null : src.Dishes));

        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(d => d.Address, opt => opt.MapFrom(src => new Address
            {
                City = src.City,
                PostalCode = src.PostalCode,
                Street = src.Street
            }));

        CreateMap<UpdateRestaurantCommand, Restaurant>();


    }


}
