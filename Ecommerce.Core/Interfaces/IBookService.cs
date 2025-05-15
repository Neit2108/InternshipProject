using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Core.DTOs.Books;

namespace Ecommerce.Core.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetAllBooksAsync();
        Task<BookResponse> GetBookByIdAsync(int id);
        Task AddBookAsync(BookRequest book);
    }
}
