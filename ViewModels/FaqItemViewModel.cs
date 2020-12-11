using System.ComponentModel.DataAnnotations;


namespace Bazar.ViewModel
{
    public class FaqItemViewModel
    {
        public int FaqItemId { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        [Display(Name = "Вопрос")]
        public string Question { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        [Display(Name = "Ответ")]
        public string Answer { get; set; }

        
        [Display(Name = "Порядок")]
        public int? Order { get; set; }

    }
}