using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazar.Domain.Entities;

namespace Bazar
{
    public interface ICarouselSlideRepository
    {
        IEnumerable<CarouselSlide> GetCarouselSlides();

        CarouselSlide GetCarouselSlide(int id);
        void AddCarouselSlide(CarouselSlide item);

        void UpdateCarouselSlide(int id, CarouselSlide item);

        void DeleteCarouselSlide(int id);
    }
}
