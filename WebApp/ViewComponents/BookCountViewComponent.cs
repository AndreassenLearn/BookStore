using DataLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewComponents
{
    public class BookCountViewComponent : ViewComponent
    {
        //private readonly BookService _bookService;

        //public BookCountViewComponent(BookService bookService)
        //{
        //    _bookService = bookService;
        //}

        public IViewComponentResult Invoke()
        {
            using (var context = new EfCoreContext())
            {
                int count = new BookService(context).Count();
                return View(count);
            }
        }
    }
}
