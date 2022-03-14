using AutoMapper;
using ETicketsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Mappings
{
    public class OrderItemMapper : Profile
    {
        public OrderItemMapper()
        {
            CreateMap<ShoppingCartItem, OrderItem>()
                .ForMember(dest => dest.MovieId, opt => {
                    opt.PreCondition(src => src.Movie is not null);
                    opt.MapFrom(src => src.Movie.Id);
                })
                .ForMember(dest => dest.Price, opt => {
                    opt.PreCondition(src => src.Movie is not null);
                    opt.MapFrom(src => src.Movie.Price);
                })
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
