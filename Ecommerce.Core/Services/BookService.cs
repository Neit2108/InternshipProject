using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Core.DTOs.Books;
using Ecommerce.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;
        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public Task AddBookAsync(BookRequest book)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookResponse>> GetAllBooksAsync()
        {
            try
            {
                var books = await _bookRepository.GetAllBooksAsync();
                var bookResponses = books.Select(b => new BookResponse
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    Price = b.Price,
                    Stock = b.Stock,    
                    Category = b.Categories.FirstOrDefault().Name,
                    Images = b.Images.Select(i => i.Url).ToList(),
                    Authors = b.Authors.Select(a => a.FullName).ToList()
                }).ToList();
                return bookResponses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy sách: {Message}", ex.Message);
                return Enumerable.Empty<BookResponse>();
            }
        }

        public async Task<BookResponse> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await _bookRepository.GetBookByIdAsync(id);
                if(book == null)
                {
                    _logger.LogWarning("Không tìm thấy sách với ID: {Id}", id);
                    return null;
                }
                return new BookResponse
                {
                    Id = id,
                    Name = book.Name,
                    Description = book.Description,
                    Price = book.Price,
                    Stock = book.Stock,
                    Category = book.Categories.FirstOrDefault().Name,
                    Images = book.Images.Select(i => i.Url).ToList(),
                    Authors = book.Authors.Select(a => a.FullName).ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy sách với ID {Id}: {Message}", id, ex.Message);
                return null;
            }
        }
    }
}
