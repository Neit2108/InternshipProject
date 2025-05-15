using Ecommerce.Core.DTOs.Books;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Enums;
using Ecommerce.Core.Interfaces;
using Ecommerce.Core.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace Ecommerce.UnitTests;

[TestClass]
public class BookServiceTests
{
    private Mock<IBookRepository> _bookRepositoryMock;
    private Mock<ILogger<BookService>> _loggerMock;
    private BookService _bookService;

    [TestInitialize]
    public void Initialize()
    {
        _bookRepositoryMock = new Mock<IBookRepository>();
        _loggerMock = new Mock<ILogger<BookService>>();
        _bookService = new BookService(_bookRepositoryMock.Object, _loggerMock.Object);
    }

    [TestMethod]
    public async Task GetBookByIdAsync_ReturnsBookResponse_WhenBookExists()
    {
        var book = new Book
        {
            Id = 1,
            Name = "Sample Book",
            Description = "Desc",
            Price = 123,
            Stock = 5,
            Categories = new List<Category> {
                new Category
                {
                    Id = 2,
                    Name = "Sci-Fi"
                }
            },
            Authors = new List<Author> { 
                new Author { Id = 1, FullName = "Author example", BirthDate = DateTime.UtcNow, Email = "example@gmail.com" }
            }
        };
        _bookRepositoryMock.Setup(r => r.GetBookByIdAsync(1)).ReturnsAsync(book);

        var result = await _bookService.GetBookByIdAsync(1);

        Assert.IsNotNull(result);
        Assert.AreEqual("Sample Book", result.Name);
        Assert.AreEqual("Sci-Fi", result.Category);
        Assert.AreEqual("Author example", result.Authors[0]);
    }

    [TestMethod]
    public async Task GetBookByIdAsync_ReturnsNull_AndLogsWarning_WhenBookNotFound()
    {
        // Arrange
        _bookRepositoryMock.Setup(r => r.GetBookByIdAsync(999)).ReturnsAsync((Book)null);

        // Act
        var result = await _bookService.GetBookByIdAsync(999);

        // Assert
        Assert.IsNull(result);
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Warning,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Không tìm thấy sách")),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once
        );
    }

    [TestMethod]
    public async Task GetBookByIdAsync_ReturnsNull_AndLogsError_WhenExceptionThrown()
    {
        // Arrange
        _bookRepositoryMock.Setup(r => r.GetBookByIdAsync(It.IsAny<int>())).ThrowsAsync(new Exception("Lỗi DB"));

        // Act
        var result = await _bookService.GetBookByIdAsync(1);

        // Assert
        Assert.IsNull(result);
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Lỗi khi lấy sách")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once
        );
    }

    [TestMethod]
    public async Task GetAllBooksAsync_ReturnsListOfBookResponses_WhenBooksExist()
    {
        var books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Name = "Sách A",
                Description = "Mô tả A",
                Price = 100000,
                Stock = 3,
                Categories = new List<Category> { new Category { Id = 1, Name = "Khoa học" } },
                //Images = new List<Image> { new Image { Id = 1, Url = "https://image1.jpg", ReferenceId = 1, ReferenceType = ImageType.Book } },
                Authors = new List<Author> { new Author { Id = 1, FullName = "Tác giả A", Email = "a@email.com", BirthDate = DateTime.Now } }
            },
            new Book
            {
                Id = 2,
                Name = "Sách B",
                Description = "Mô tả B",
                Price = 200000,
                Stock = 5,
                Categories = new List<Category> { new Category { Id = 2, Name = "Văn học" } },
                //Images = new List<Image> { new Image { Id = 2, Url = "https://image2.jpg", ReferenceId = 2, ReferenceType = ImageType.Book } },
                Authors = new List<Author> { new Author { Id = 2, FullName = "Tác giả B", Email = "b@email.com", BirthDate = DateTime.Now } }
            }
        };

        _bookRepositoryMock.Setup(repo => repo.GetAllBooksAsync()).ReturnsAsync(books);

        var result = (await _bookService.GetAllBooksAsync()).ToList();

        Assert.AreEqual(2, result.Count);

        Assert.AreEqual("Sách A", result[0].Name);
        Assert.AreEqual("Khoa học", result[0].Category);
        Assert.AreEqual("https://image1.jpg", result[0].Images.First());
        Assert.AreEqual("Tác giả A", result[0].Authors.First());

        Assert.AreEqual("Sách B", result[1].Name);
        Assert.AreEqual("Văn học", result[1].Category);
    }

    [TestMethod]
    public async Task GetAllBooksAsync_ReturnsEmptyList_AndLogsError_WhenExceptionOccurs()
    {
        // Arrange
        _bookRepositoryMock.Setup(repo => repo.GetAllBooksAsync()).ThrowsAsync(new Exception("DB lỗi"));

        // Act
        var result = await _bookService.GetAllBooksAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count());

        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, _) => v.ToString().Contains("Lỗi khi lấy sách")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once
        );
    }
}
