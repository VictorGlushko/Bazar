using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Bazar.Domain.Entities;

namespace Bazar.ViewModels
{
    public class SystemRequirementsViewModel
    {
        
        [Required]
        [DisplayName("Операционная система")]
        public string OperatingSystem { get; set; }

        [Required]
        [DisplayName("Процессор")]
        public string Processor { get; set; }

        [Required]
        [DisplayName("Оперативная память")]
        public string RAM { get; set; }

        [Required]
        [DisplayName("Видео карта")]
        public string VideoCard { get; set; }

        [Required]
        [DisplayName("Жесткий диск")]
        public string HDD { get; set; }

    }
}
