using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPlatform.Models;

namespace BookPlatform.Repositories.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        IEnumerable<Tag> GetTagsByBookId(int bookId);
        IEnumerable<Tag> GetTagsByBook(Book book);
    }
}
