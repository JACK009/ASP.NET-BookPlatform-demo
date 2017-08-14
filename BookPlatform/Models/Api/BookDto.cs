using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPlatform.Models.Api
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Int16 Pages { get; set; }
        public DateTime PublishingDate { get; set; }
        public string CoverUrl { get; set; }
    }
}