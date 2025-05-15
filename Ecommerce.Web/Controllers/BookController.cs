using Ecommerce.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly BookViewService _bookViewService;

        public BookController(BookViewService bookViewService)
        {
            _bookViewService = bookViewService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookViewService.GetAllBookViewModelsAsync();
            return View(books);
        }
    }
}
