using BookManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class BookController : Controller
    {
        private static readonly List<Book> Books = new()
        {
            new Book
            {
                Id = 1,
                Title = "Lap trinh C#",
                Price = 120000
            },

            new Book
            {
                Id = 2,
                Title = "ASP.NET Core MVC",
                Price = 150000
            }
        };

        // GET: /Book
        public IActionResult Index()
        {
            return View(Books);
        }

        // GET: /Book/Detail/1
        public IActionResult Detail(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound("Khong tim thay sach");
            }

            return View(book);
        }

        // GET: /Book/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            book.Id = Books.Count == 0
                ? 1
                : Books.Max(b => b.Id) + 1;

            Books.Add(book);

            return RedirectToAction(nameof(Index));
        }
    }
}