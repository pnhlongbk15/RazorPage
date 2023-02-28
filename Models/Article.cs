﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPage.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Created { get; set; }

        [Column(TypeName = "text")]
        public string? Content { get; set; }
    }
}
