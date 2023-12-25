﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkySelf.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Product Name")]
        [MaxLength(30)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }

        [Required]
        [DisplayName("List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [Required]
        [DisplayName("Price for 1 - 50")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [Required]
        [DisplayName("Price for 50 + ")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [Required]
        [DisplayName("Price for 100 + ")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        [ValidateNever]
        public Student Student { get; set; }
        [ValidateNever]
        public string? ImageUrl { get; set; }
    }
}
