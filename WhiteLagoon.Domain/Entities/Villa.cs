﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteLagoon.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public required string Name { get; set; }
        public string? Descreption { get; set; } = "";

        [Display(Name = "Price per night"), Range(10,1000)]
        public double? Price { get; set; }
        public required int Sqft { get; set; }

        [Range(1, 10)]
        public required int Occupancy { get; set; }
        
        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Updated_Date { get; set; }
    }
}
