using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPlatform.Models
{
    public class Cover
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public Book Book { get; set; }
    }
}