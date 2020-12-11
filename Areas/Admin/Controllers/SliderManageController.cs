using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using Bazar.Domain.Entities;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Bazar.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SliderManageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _appEnvironment;

        public SliderManageController(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment appEnvironment)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {

            var slidesViewModel = _unitOfWork.CarouselSlides.GetCarouselSlides()
                .Select(s => _mapper.Map<CarouselSlideViewModel>(s));

            return View("SliderManagePage", slidesViewModel);

        }

        public IActionResult SlideForm(CarouselSlideViewModel viewModel)
        {

            if (viewModel.Id == 0)
            {

                var slides = _unitOfWork.CarouselSlides.GetCarouselSlides();
                if (slides.Count() > 0)
                    viewModel.Order = slides.Max(s => s.Order) + 1;
                else
                    viewModel.Order = 1;

            }
            else
            {
               var slideInDb = _unitOfWork.CarouselSlides.GetCarouselSlide(viewModel.Id);
               viewModel = _mapper.Map<CarouselSlideViewModel>(slideInDb);
            }

            return View("SlideForm", viewModel);

        }


        [HttpPost]
        public IActionResult Save(CarouselSlideViewModel viewModel, IFormFile uploadImage)
        {
            /* if (!ModelState.IsValid || uploadImage == null)
                 return View("SlideForm", viewModel);*/

            if (viewModel.Id == 0)
            {
                if (uploadImage.Length > 0)
                {
                    string ext = uploadImage.ContentType.ToLower();
                    if (ext == "image/jpg" || ext == "image/jpeg" || ext == "image/png")
                    {
                        viewModel.ImgPath = UploadedFile(uploadImage, @"\img\carousel");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Не верный формат изображения");
                    }
                }

                _unitOfWork.CarouselSlides.AddCarouselSlide(_mapper.Map<CarouselSlide>(viewModel));
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            else
            {
                viewModel.ImgPath = UploadedFile(uploadImage ,@"\img\carousel" );
                _unitOfWork.CarouselSlides.UpdateCarouselSlide(viewModel.Id, _mapper.Map<CarouselSlide>(viewModel));
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

        }




        private string UploadedFile(IFormFile uploadImage, string folderPaath)
        {
            var uploadsFolder = _appEnvironment.WebRootPath + folderPaath;
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = null;
            uniqueFileName = Guid.NewGuid() + "_" + uploadImage.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            var img = SixLabors.ImageSharp.Image.Load(uploadImage.OpenReadStream());
            img.Mutate(x => x.Resize(800, 400));
            img.Save(filePath);

            return folderPaath + uniqueFileName;

        }

    }

}
