using System.ComponentModel.DataAnnotations;

namespace Bazaar.ViewModel
{
    public class SlideViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]

        public string Link { get; set; }
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public int? Price { get; set; }
    }
}