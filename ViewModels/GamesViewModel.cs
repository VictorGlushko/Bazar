using System.Collections.Generic;
using Bazaar.ViewModel;
using Bazar.Domain.Entities;


namespace Bazar.ViewModel
{
    public class GamesViewModel
    {

        public List<Game> Games { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Game> DiscountGames { get; set; }
        public List<SlideViewModel> Slides { get; set; }
    }
}
