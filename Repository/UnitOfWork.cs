using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bazar.Data;
using Bazar.Domain.Entities;

namespace Bazar
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGameRepository Games { get; }
        public IGenreRepository Genres { get; }
        public IModeRepository Mode { get; set; }
        public IPlatformRepository Platform { get; }
        public IFaqItemRepository FaqItem { get; }
        public ICarouselSlideRepository CarouselSlides { get; }
        public ICommentRepository Comments { get; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
          /*  Games = new GameRepository(context);
            Genres = new GenreRepository(context);
            Mode = new ModeRepository(context);
            Platform = new PlatformRepository(context);
            FaqItem = new FaqItemRepository(context);*/
            CarouselSlides = new CarouselSlideRepository(context);
           // Comments = new CommentRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}