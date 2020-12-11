using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bazar.Domain.AdditionalClasses;
using Bazar.Domain.Entities;
using Bazar.Models;
using Bazar.ViewModel;
using Bazar.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Bazar.Areas.Admin.Controllers
{
    [Area("admin")]
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

        public IActionResult GameForm(GameFormViewModel viewModel)
        {

            if (viewModel.Id == 0)
            {
                viewModel.AllGenres = _unitOfWork.Genres.GetGenres().Select(g => g.Name);
                viewModel.AllModest = _unitOfWork.Mode.GetModes().Select(m => m.Name);
                viewModel.AllPlatforms = _unitOfWork.Platform.GetPlatforms().Select(p => p.Name);

            }
            else
            {
                var gameInDb = _unitOfWork.Games.GetGame(viewModel.Id);
                viewModel = _mapper.Map<GameFormViewModel>(gameInDb);

                viewModel.AllGenres = _unitOfWork.Genres.GetGenres().Select(g => g.Name);
                viewModel.AllModest = _unitOfWork.Mode.GetModes().Select(m => m.Name);
                viewModel.AllPlatforms = _unitOfWork.Platform.GetPlatforms().Select(p => p.Name);

                viewModel.SelectedGenres = gameInDb.Genres.Select(g => g.Name);
                viewModel.SelectedModes = gameInDb.Modes.Select(m => m.Name);
                viewModel.SelectedPlatforms = gameInDb.Platforms.Select(p => p.Name);
                viewModel.PosterPath = gameInDb.MediaResources.MainImagePath;
                viewModel.VideoLink = gameInDb.MediaResources.VideoLink;
                viewModel.SystemRequirementsVM = _mapper.Map<SystemRequirementsViewModel>(gameInDb.SystemRequirements);

                

                string imagesPath = Tools.GetGalleryPathOfGame(viewModel.Slug);
                var appData = _appEnvironment.WebRootPath + imagesPath;
                var images = Directory.GetFiles(appData).Select(x => imagesPath + Path.GetFileName(x));

                viewModel.GalleryImages = images;
            }

            return View("GameForm", viewModel);

        }



        [HttpPost]
        public async Task<IActionResult> AddContentImage(IEnumerable<IFormFile> files)
        {

            var uploadsFolder = $"{_appEnvironment.WebRootPath}\\img\\content";
            var vOriginalDirectory = @"\img\content\";

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string output = "";
            foreach (var img in files)
            {

                string ext = img.ContentType.ToLower();
                if (ext == "image/jpg" || ext == "image/jpeg" || ext == "image/png")
                {
                    string uniqueFileName = null;
                    uniqueFileName = Guid.NewGuid() + "_" + img.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    string returnPath = Path.Combine(vOriginalDirectory, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await img.CopyToAsync(fileStream);
                    }

                    output += "<li>" + returnPath + "</li>";
                }
                else
                {
                    output += "Не верный формат изображения файла : " + img.FileName;

                }

            }

            return Content(output);

        }


        [HttpPost]
        public IActionResult Save(GameFormViewModel viewModel)
        {
            /*
            *сделать валидацию картинок (атрибут)
            * https://stackoverflow.com/questions/56588900/how-to-validate-uploaded-file-in-asp-net-core
            *проверть уже сущ игру
            *проверить кривые имена игр
            *
            */

            if (!ModelState.IsValid)
            {
                viewModel.AllGenres = _unitOfWork.Genres.GetGenres().Select(g => g.Name);
                viewModel.AllModest = _unitOfWork.Mode.GetModes().Select(m => m.Name);
                viewModel.AllPlatforms = _unitOfWork.Platform.GetPlatforms().Select(p => p.Name);
                return View("GameForm", viewModel);
            }


            if (viewModel.Id == 0)//если игра новая
            {

                string slug = viewModel.Name.GenerateSlug();

                if (_unitOfWork.Games.GetGames().Any(g => g.Slug.Equals(slug))) //если такая игра уже есть
                {
                    viewModel.AllGenres = _unitOfWork.Genres.GetGenres().Select(g => g.Name);
                    viewModel.AllModest = _unitOfWork.Mode.GetModes().Select(m => m.Name);
                    viewModel.AllPlatforms = _unitOfWork.Platform.GetPlatforms().Select(p => p.Name);
                    ModelState.AddModelError("", "That game name is taken!");

                    return View("GameForm", viewModel);
                }


                var newGame = _mapper.Map<Game>(viewModel);
                newGame.Slug = slug;


                //media
                var mediaResources = new MediaResources();

                if (viewModel.Poster == null)
                    mediaResources.MainImagePath = @"/img/default.jpg";
                else
                    mediaResources.MainImagePath = UploadedFile(viewModel.Poster, Tools.GetImagesPathOfGame(newGame.Slug));


                mediaResources.GalleryPath = UploadedScreens(viewModel.Screens, Tools.GetGalleryPathOfGame(newGame.Slug));
                mediaResources.VideoLink = viewModel.VideoLink;

                newGame.MediaResources = mediaResources;
                //media


                newGame.Genres = _unitOfWork.Genres.GetGenres()
                    .Where(s => viewModel.SelectedGenres.Contains(s.Name)).ToList();


                newGame.Modes = _unitOfWork.Mode.GetModes()
                    .Where(s => viewModel.SelectedModes.Contains(s.Name)).ToList();


                newGame.Platforms = _unitOfWork.Platform.GetPlatforms()
                    .Where(s => viewModel.SelectedPlatforms.Contains(s.Name)).ToList();


                newGame.SystemRequirements = _mapper.Map<SystemRequirements>(viewModel.SystemRequirementsVM);
                newGame.DateAdded = DateTime.Now;

                _unitOfWork.Games.Add(newGame);
                _unitOfWork.Complete();

            }
            else
            {
                var gameIdDb = _unitOfWork.Games.GetGame(viewModel.Id);


                string slug = viewModel.Name.GenerateSlug();

                if (gameIdDb.Slug != slug)
                {
                    if (_unitOfWork.Games.GetGames().Any(g => g.Slug.Equals(slug))) //если такая игра уже есть
                    {
                        viewModel.AllGenres = _unitOfWork.Genres.GetGenres().Select(g => g.Name);
                        viewModel.AllModest = _unitOfWork.Mode.GetModes().Select(m => m.Name);
                        viewModel.AllPlatforms = _unitOfWork.Platform.GetPlatforms().Select(p => p.Name);
                        ModelState.AddModelError("", "That game name is taken!");

                        return View("GameForm", viewModel);
                    }
                }

                gameIdDb.Name = viewModel.Name;
                gameIdDb.Slug = slug;
                gameIdDb.Description = viewModel.Description;
                gameIdDb.OriginalPrice = viewModel.OriginalPrice;
                gameIdDb.FinalPrice = viewModel.FinalPrice;
                gameIdDb.Publisher = viewModel.Publisher;
                gameIdDb.Developer = viewModel.Developer;
                gameIdDb.Language = viewModel.Language;
                gameIdDb.ReleaseDate = viewModel.ReleaseDate;
                
                if(viewModel.Poster != null)
                    gameIdDb.MediaResources.MainImagePath = UploadedFile(viewModel.Poster, Tools.GetImagesPathOfGame(gameIdDb.Slug));


                if (viewModel.GalleryImages != null)
                {

                    var imgName = viewModel.GalleryImages.Select(i => Path.GetFileName(i));

                    var appData = _appEnvironment.WebRootPath + Tools.GetGalleryPathOfGame(gameIdDb.Slug);

                    foreach (var img in Directory.GetFiles(appData))
                    {
                        var name = Path.GetFileName(img);
                        if (!imgName.Contains(name))
                        {
                            System.IO.File.Delete(img);
                        }

                        //if(!viewModel.GalleryImages.Contains())
                    }
                }

                if(viewModel.Screens != null)
                    UploadedScreens(viewModel.Screens, Tools.GetGalleryPathOfGame(gameIdDb.Slug));


                gameIdDb.MediaResources.VideoLink = viewModel.VideoLink;


                gameIdDb.Genres = _unitOfWork.Genres.GetGenres()
                    .Where(s => viewModel.SelectedGenres.Contains(s.Name)).ToList();


                gameIdDb.Modes = _unitOfWork.Mode.GetModes()
                    .Where(s => viewModel.SelectedModes.Contains(s.Name)).ToList();


                gameIdDb.Platforms = _unitOfWork.Platform.GetPlatforms()
                    .Where(s => viewModel.SelectedPlatforms.Contains(s.Name)).ToList();


                gameIdDb.SystemRequirements.HDD = viewModel.SystemRequirementsVM.HDD;
                gameIdDb.SystemRequirements.OperatingSystem = viewModel.SystemRequirementsVM.OperatingSystem;
                gameIdDb.SystemRequirements.Processor = viewModel.SystemRequirementsVM.Processor;
                gameIdDb.SystemRequirements.VideoCard = viewModel.SystemRequirementsVM.VideoCard;
                gameIdDb.SystemRequirements.RAM = viewModel.SystemRequirementsVM.RAM;


                _unitOfWork.Complete();
            }




            /* if (viewModel.Id == 0)
             {
                 if (uploadImage.Length > 0)
                 {
                     string ext = uploadImage.ContentType.ToLower();
                     if (ext == "image/jpg" || ext == "image/jpeg" || ext == "image/png")
                     {

                         viewModel.ImgPath = UploadedFile(uploadImage);
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
                 viewModel.ImgPath = UploadedFile(uploadImage);
                 _unitOfWork.CarouselSlides.UpdateCarouselSlide(viewModel.Id, _mapper.Map<CarouselSlide>(viewModel));
                 _unitOfWork.Complete();
                 return RedirectToAction("Index");
             }*/

            return RedirectToAction("Index");
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

            return folderPaath + "\\" + uniqueFileName;

        }

        private string UploadedScreens(IEnumerable<IFormFile> screens, string folderPath)
        {
            var uploadsFolder = _appEnvironment.WebRootPath + folderPath;
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            foreach (var item in screens)
            {
                string uniqueFileName = null;
                uniqueFileName = Guid.NewGuid() + "_" + item.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                var img = SixLabors.ImageSharp.Image.Load(item.OpenReadStream());
                img.Mutate(x => x.Resize(800, 600));
                img.Save(filePath);
            }



            return folderPath;

        }



        /* public async Task<IActionResult> Upload(IFormFile file)

        {

            var FileDic = "Files";

            string FilePath = Path.Combine(_appEnvironment.WebRootPath, FileDic);

            if (!Directory.Exists(FilePath))

                Directory.CreateDirectory(FilePath);

            var fileName = file.FileName;

            var filePath = Path.Combine(FilePath, fileName);

            using (FileStream fs = System.IO.File.Create(filePath))

            {

                file.CopyTo(fs);

            }

            return Ok();

        }*/
    }
}
