using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookPlatform.Context;
using BookPlatform.Repositories.Interfaces;

namespace BookPlatform.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookContext _context;

        public IAuthorRepository Authors { get; }
        public IBookRepository Books { get; }
        public ICoverRepository Covers { get; }
        public ITagRepository Tags { get; }

        public UnitOfWork(BookContext context)
        {
            _context = context;
            Authors = new AuthorRepository(_context);
            Books = new BookRepository(_context);
            Covers = new CoverRepository(_context);
            Tags = new TagRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}