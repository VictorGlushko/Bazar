using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Domain.Entities;
using Bazar.Domain.ViewModel;

namespace Bazar.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CarouselSlide, CarouselSlideViewModel>();
            CreateMap<CarouselSlideViewModel, CarouselSlide>();
        }
    }
}
