using BookPlatform.Context;
using BookPlatform.Models;
using BookPlatform.Models.Api;
using BookPlatform.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookPlatform.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public BookContext BookContext => Context as BookContext;

        public AuthorRepository(BookContext context) : base(context)
        {
        }

        public Author GetAuthorByBookId(int bookId)
        {
            return BookContext.Authors
                .Where(c => c.Books.Any(b => b.Id == bookId))
                .Include(c => c.Books)
                .Single();
        }

        public Author GetAuthorByBook(Book book)
        {
            return GetAuthorByBookId(book.Id);
        }

        public IEnumerable<AuthorDto> GetAuthorsDto()
        {
            return BookContext.Authors
                .Include(a => a.Books)
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    LastName = a.LastName,
                    Books = a.Books.Select(
                        b => new BookDto
                        {
                            Id = b.Id,
                            Isbn = b.Isbn,
                            Title = b.Title,
                            Description = b.Description,
                            Pages = b.Pages,
                            PublishingDate = b.PublishingDate,
                            CoverUrl = b.Cover.ImageUrl
                        })
                });
        }

        public AuthorDto GetAuthorDto(int id)
        {
            return BookContext.Authors
                .Include(a => a.Books)
                .Where(a => a.Id == id)
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    LastName = a.LastName,
                    Books = a.Books.Select(
                        b => new BookDto
                        {
                            Id = b.Id,
                            Isbn = b.Isbn,
                            Title = b.Title,
                            Description = b.Description,
                            Pages = b.Pages,
                            PublishingDate = b.PublishingDate,
                            CoverUrl = b.Cover.ImageUrl
                        })
                })
                .FirstOrDefault();
        }

        public IEnumerable<AuthorDto> GetAuthorDtoByNameWithLimit(string name, int limit)
        {
            return BookContext.Authors
                .Include(a => a.Books)
                .Where(a => String.Concat(a.Name, " ", a.LastName).Contains(name))
                .Select(a => new AuthorDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    LastName = a.LastName,
                    Books = a.Books.Select(
                        b => new BookDto
                        {
                            Id = b.Id,
                            Isbn = b.Isbn,
                            Title = b.Title,
                            Description = b.Description,
                            Pages = b.Pages,
                            PublishingDate = b.PublishingDate,
                            CoverUrl = b.Cover.ImageUrl
                        })
                })
                .Take(limit);
        }
    }
}