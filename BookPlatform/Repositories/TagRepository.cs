using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BookPlatform.Context;
using BookPlatform.Models;
using BookPlatform.Repositories.Interfaces;

namespace BookPlatform.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public BookContext BookContext => Context as BookContext;

        public TagRepository(BookContext context) : base (context)
        {
        }

        public IEnumerable<Tag> GetTagsByBookId(int bookId)
        {
            return BookContext.Tags
                .Where(t => t.Books.Any(b => b.Id == bookId))
                .Include(t => t.Books)
                .ToList();
        }

        public IEnumerable<Tag> GetTagsByBook(Book book)
        {
            return GetTagsByBookId(book.Id);
        }
    }
}