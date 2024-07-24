using System;
using System.ComponentModel.DataAnnotations;

namespace Bloggie.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }  // Foreign key

        public Category Category { get; set; }  // Navigation property

        public string ImagePath { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
