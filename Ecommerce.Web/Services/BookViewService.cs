using Ecommerce.Core.Interfaces;
using Ecommerce.Web.Models;

namespace Ecommerce.Web.Services
{
    public class BookViewService
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookViewService> _logger;
        public BookViewService(IBookService bookService, ILogger<BookViewService> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        public async Task<BookViewModel> GetBookViewModelByIdAsync(int id)
        {
            try
            {
                var book = await _bookService.GetBookByIdAsync(id);
                if (book == null)
                {
                    return null;
                }
                return new BookViewModel
                {
                    Id = book.Id,
                    Name = book.Name,
                    Description = book.Description,
                    Price = book.Price,
                    Stock = book.Stock,
                    Category = book.Category,
                    Images = book.Images,
                    Authors = book.Authors
                };
            }
            catch (Exception ex)
            {   
                _logger.LogError("Lỗi khi lấy sách: {Message}", ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAllBookViewModelsAsync()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                return books.Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    Price = b.Price,
                    Stock = b.Stock,
                    Category = b.Category,
                    Images = b.Images,
                    Authors = b.Authors
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi khi lấy danh sách sách: {Message}", ex.Message);
                return Enumerable.Empty<BookViewModel>();
            }
        }
         
    }
}
