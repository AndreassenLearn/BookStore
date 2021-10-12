using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceLayer.BookService;
using ServiceLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<ListBookDto> Books { get; private set; }

        public void OnGet()
        {
            using (var context = new EfCoreContext())
            {
                var bookService = new BookService(context);
                
                Books = bookService.GetListBooks().ToList();
            }
        }
    }
}
