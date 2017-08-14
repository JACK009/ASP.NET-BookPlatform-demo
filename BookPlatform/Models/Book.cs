using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace BookPlatform.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Isbn { get; set; }

        [MinLength(2)]
        public string Title { get; set; }
        public string Description { get; set; }
        public Int16 Pages { get; set; }
        public DateTime PublishingDate { get; set; }

        public Cover Cover { get; set; }
        public Author Author { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}