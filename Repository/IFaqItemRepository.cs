using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazar.Domain.Entities;

namespace Bazar
{
    public interface IFaqItemRepository
    {
        IEnumerable<FaqItem> GetFaqItems();

        FaqItem GetFaqItem(int id);

        void AddFaqItem(FaqItem item);

        void UpdateFaqItem(int id, FaqItem item);

        void DeleteFaqItem(int id);

    }
}
