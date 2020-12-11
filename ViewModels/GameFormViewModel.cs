using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Bazar.Domain.Entities;
using Bazar.ViewModels;
using Microsoft.AspNetCore.Http;
    

namespace Bazar.ViewModel
{
    public class GameFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Description { get; set; }

        public string Slug { get; set; }

        [Required]
        [DisplayName("Изначальная цена")]
        public int OriginalPrice { get; set; }

        [Required]
        [DisplayName("Окончательная цена")]
        public int FinalPrice { get; set; }


        [Required]
        [DisplayName("Дата выхода")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Издатель")]
        public string Publisher { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Разработчик")]
        public string Developer { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Язык")]
        public string Language { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public int Quantity { get; set; }


        public IEnumerable<string> AllGenres { get; set; }
        public IEnumerable<string> AllModest { get; set; }
        public IEnumerable<string> AllPlatforms { get; set; }


        [Required]
        public IEnumerable<string> SelectedGenres { get; set; }
        [Required]
        public IEnumerable<string> SelectedModes { get; set; }
        [Required]
        public IEnumerable<string> SelectedPlatforms { get; set; }

        public IFormFile Poster { get; set; }

        public string PosterPath { get; set; }

        public IEnumerable<IFormFile> Screens { get; set; }
        public IEnumerable<string> GalleryImages { get; set; }

        public string VideoLink { get; set; }

        public SystemRequirementsViewModel SystemRequirementsVM { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
