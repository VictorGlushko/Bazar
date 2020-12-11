using System.Collections.Generic;

using Bazar.Domain.Entities;

namespace Bazar.ViewModel
{
    public class CatalogViewModel
    {
        public List<Genre> Genres { get; set; }
        public List<Platform> Platforms { get; set; }
        public List<Mode> Modes { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        

    }

    public class FromCatalogViewModel
    {
        public List<string> Genres { get; set; }
        public List<string> Platforms { get; set; }
        public List<string> Modes { get; set; }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string Sorting { get; set; }
        public string Order { get; set; } = "ASC";

        public static string OrderASC = "ASC";
        public static string OrderDESC = "DESC";
    }
}
