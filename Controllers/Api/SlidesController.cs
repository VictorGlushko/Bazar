using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Domain.Dto;
using Bazar.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Bazar.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ILogger<HomeController> _logger;


        public SlidesController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment appEnvironment, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
            _logger = logger;
        }


        //GET /api/Slides
        [HttpGet]
        public ActionResult<IEnumerable<CarouselSlideDto>> GetCarouselSlides()
        {
            try
            {
                return _unitOfWork.CarouselSlides.GetCarouselSlides().Select(s => _mapper.Map<CarouselSlideDto>(s)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCarouselSlides action: {ex.Message}");
                return null;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCarouselSlide(int id)
        {
            try
            {
                var faqItem = _unitOfWork.CarouselSlides.GetCarouselSlide(id);

                if (faqItem == null)
                {
                    _logger.LogError($"Slide with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _unitOfWork.CarouselSlides.DeleteCarouselSlide(id);
                _unitOfWork.Complete();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteCarouselSlide action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
