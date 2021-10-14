using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.BookService;
using ServiceLayer.Conrete;

namespace WebApp.Pages.Books
{
    public class DetailsBookModel : PageModel
    {
        public DetailsBookDto Book { get; set; }

        public void OnGet(int? bookId)
        {
            using (var context = new EfCoreContext())
            {
                BookService bookService = new(context);

                Book = bookService.GetDetailsBook(bookId);
            }
        }

        public IActionResult OnGetBookId(int bookId)
        {
            using (var context = new EfCoreContext())
            {
                BookService bookService = new(context);

                Book = bookService.GetDetailsBook(bookId);
            }

            return Page();
        }
    }
}
