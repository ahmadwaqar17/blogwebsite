using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bloggie.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation property
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
