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
    public class RegisterMapper : Profile
    {
        public RegisterMapper()
        {
            CreateMap<ApplicationUser, RegisterVM>()
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
        }
    }
}
