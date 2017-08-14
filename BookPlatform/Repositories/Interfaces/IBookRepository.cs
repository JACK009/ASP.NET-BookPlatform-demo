using BookPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookPlatform.Repositories.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetByIsbn(string isbn);
        IEnumerable<Book> GetBooksWithTags(int pageIndex, int pageSize);
        IEnumerable<Book> GetBooksByAuthor(Author author);
    }
}
