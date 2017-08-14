using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookPlatform.Models
{
    public class Author
    {
        public int Id { get; set; }

        [MinLength(2)]
        public string Name { get; set; }

        [MinLength(2)]
        public string LastName { get; set; }
        public string FullName => $"{Name} {LastName}";
        
        [EmailAddress]
        public string Email { get; set; }
        
        public ICollection<Book> Books { get; set; }
    }
}