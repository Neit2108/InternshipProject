using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Enums;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly EcommerceDbContext _context;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(EcommerceDbContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task AddBookAsync(Book book)
        {
            try
            {
                if(book == null)
                {
                    throw new ArgumentNullException(nameof(book), "Sách không được null");
                }
                var existingBook = await _context.Books.FindAsync(book.Id);
                if (existingBook != null)
                {
                    throw new InvalidOperationException("Đã tồn tại sách này rồi");
                }
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi thêm sách mới: {Message}", ex.Message);
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            try
            {
                var existingBook = await _context.Books.FindAsync(id);
                if (existingBook == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy sách với ID {id}");
                }
                _context.Books.Remove(existingBook);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa sách: {Message}", ex.Message);
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            try
            {
                var books = await _context.Books
                    .Include(b => b.Categories)
                    .Include(b => b.Authors)
                    .ToListAsync();

                if (!books.Any())
                {
                    throw new InvalidOperationException("Không có sách nào trong danh sách");
                }
                return books;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách sách: {Message}", ex.Message);
                return Enumerable.Empty<Book>();
            }
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await _context.Books
                    .Include(b => b.Categories)
                    .Include(b => b.Authors)
                    .FirstOrDefaultAsync(b => b.Id == id);

                if (book == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy sách với ID {id}");
                }
                return book;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy sách theo ID: {Message}", ex.Message);
                return null;
            }
        }

        public async Task UpdateBookAsync(Book book)
        {
            try
            {
                var existingBook = await _context.Books.FindAsync(book.Id);
                if (existingBook == null)
                {
                    throw new KeyNotFoundException($"Không tìm thấy sách với ID {book.Id}");
                }
                existingBook.Name = book.Name;
                existingBook.Description = book.Description;
                existingBook.Price = book.Price;
                existingBook.Stock = book.Stock;
                existingBook.UpdatedAt = DateTime.UtcNow;
                existingBook.Categories = book.Categories;
                existingBook.Authors = book.Authors;

                _context.Books.Update(existingBook);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật sách: {Message}", ex.Message);
            }
        }
    }
}
