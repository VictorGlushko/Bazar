using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Domain.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Bazar.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ILogger<HomeController> _logger;


        public GamesController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment appEnvironment, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
            _logger = logger;
        }

        //GET /api/Slides
        [HttpGet]
        public ActionResult<IEnumerable<GameDto>> GetGames()
        {
            try
            {
                return _unitOfWork.Games.GetGames().Select(s => _mapper.Map<GameDto>(s)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetGames action: {ex.Message}");
                return null;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGame(int id)
        {
            try
            {
                var gameItem = _unitOfWork.Games.GetGame(id);

                if (gameItem == null)
                {
                    _logger.LogError($"GAme with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _unitOfWork.Games.Remove(gameItem);
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
