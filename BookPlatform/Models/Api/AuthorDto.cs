﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPlatform.Models.Api
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IEnumerable<BookDto> Books { get; set; }
    }
}