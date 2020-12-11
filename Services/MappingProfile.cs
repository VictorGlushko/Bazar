using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Domain.Dto;
using Bazar.Domain.Entities;
using Bazar.ViewModel;
using Bazar.ViewModels;

namespace Bazar.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CarouselSlide, CarouselSlideViewModel>();
            CreateMap<CarouselSlideViewModel, CarouselSlide>();

            CreateMap<CarouselSlide, CarouselSlideDto>();
            CreateMap<CarouselSlideDto, CarouselSlide>();

            CreateMap<Game, GameFormViewModel>();
            CreateMap<GameFormViewModel, Game>();

            CreateMap<SystemRequirements, SystemRequirementsViewModel>();
            CreateMap<SystemRequirementsViewModel, SystemRequirements>();

            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>();
        }
    }
}
