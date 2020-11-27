using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bazar.Domain.Entities;

namespace Bazar
{
    public interface IPlatformRepository
    {
        IEnumerable<Platform> GetPlatforms();
    }
}
