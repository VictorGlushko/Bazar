using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;

namespace Bazar.Areas.Admin.Controllers
{
    public class GamesManagerController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;

        public GamesManagerController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return View("GamesManagerPage");
        }
    }
}
