using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.ViewModels
{
    public class ProductViewModel
    {
        public long? Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string? Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        [Range(1, 99999.99)]
        public decimal? Price { get; set; }
    }
}
