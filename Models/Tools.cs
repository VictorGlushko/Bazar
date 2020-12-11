using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Bazar.Models
{
    public class Tools
    {
        public static string GetGalleryPathOfGame(string slug)
        {
            return $"\\img\\games\\{slug}\\gallery\\";
        }
        public static string GetImagesPathOfGame(string slug)
        {
            return $"\\img\\games\\{slug}\\";
        }
    }
}
