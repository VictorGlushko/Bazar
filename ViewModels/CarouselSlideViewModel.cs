using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Bazar.ViewModel
{
    public class CarouselSlideViewModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Порядок")]
        public int Order { get; set; }
        [Required]
        [DisplayName("Описание")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Ссылка")]
        public string Link { get; set; }
        [DisplayName("Заголовок")]
        public string Title { get; set; }
        [DisplayName("Картинка")]
        public string ImgPath { get; set; }
        [DisplayName("Цена")]
        public int? Price { get; set; }
    }
}
