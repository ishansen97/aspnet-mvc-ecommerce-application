using AutoMapper;
using ETicketsStore.Data.ViewModels;
using ETicketsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicketsStore.Data.Mappings
{
    public class MovieMapper : Profile
    {
        public MovieMapper()
        {
            CreateMap<Movie, NewMovieVM>()
                .ForMember(dest => dest.ActorIds, opt => opt.MapFrom(src => src.ActorMovies.Select(am => am.ActorId).ToList()))
                .ReverseMap();
        }
    }
}
