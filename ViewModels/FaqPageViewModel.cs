using System.Collections.Generic;
using Bazar.Domain.Entities;


namespace Bazar.ViewModel
{
    public class FaqPageViewModel
    {
        public IEnumerable<FaqItemViewModel> FaqItemViewModels { get; set; }
        public ContactForm ContactForm { get; set; }
    }
}
