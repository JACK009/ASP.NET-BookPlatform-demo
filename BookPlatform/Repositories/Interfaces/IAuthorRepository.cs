using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPlatform.Models;
using BookPlatform.Models.Api;

namespace BookPlatform.Repositories.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorByBookId(int bookId);
        Author GetAuthorByBook(Book book);
        IEnumerable<AuthorDto> GetAuthorsDto();
        AuthorDto GetAuthorDto(int id);
        IEnumerable<AuthorDto> GetAuthorDtoByNameWithLimit(string name, int limit);
    }
}
