using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookPlatform.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [MinLength(2)]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}