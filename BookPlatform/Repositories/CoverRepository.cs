using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookPlatform.Context;
using BookPlatform.Models;
using BookPlatform.Repositories.Interfaces;

namespace BookPlatform.Repositories
{
    public class CoverRepository : Repository<Cover> , ICoverRepository
    {
        public BookContext BookContext => Context as BookContext;

        public CoverRepository(BookContext context) : base(context)
        {
        }
    }
}