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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookContext BookContext => Context as BookContext;

        public BookRepository(BookContext context) : base(context)
        {
        }

        public Book GetByIsbn(string isbn)
        {
            return BookContext.Books.SingleOrDefault(b => b.Isbn == isbn);
        }

        public IEnumerable<Book> GetBooksWithTags(int pageIndex, int pageSize)
        {
            return BookContext.Books.Include(b => b.Tags)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(Author author)
        {
            return BookContext.Books
                .Where(b => b.Author.Id == author.Id)
                .Include(b => b.Author)
                .ToList();
        }
    }
}