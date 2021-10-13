using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ServiceLayer.BookService;
using ServiceLayer.Conrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ServiceLayer.BookService.BookSort;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public enum EPageSize : ushort
        {
            [Display(Name = "1")]
            PS1 = 1,
            [Display(Name = "2")]
            PS2 = 2,
            [Display(Name = "10")]
            PS10 = 10,
        }
        
        [BindProperty(SupportsGet = true)]
        public string SearchParam { get; set; }
        [BindProperty(SupportsGet = true), Display(Name = "Order by")]
        public OrderByOptions OrderByOption { get; set; }
        [BindProperty(SupportsGet = true), Display(Name = "Price offers only")]
        public bool HasPriceOffer { get; set; }
        [BindProperty(SupportsGet = true), Display(Name = "Page size")]
        public EPageSize PageSize { get; set; } = EPageSize.PS10;
        [BindProperty(SupportsGet = true)]
        public ushort PageNumber { get; set; } = 1;
        public ushort NumberOfPages { get; private set; }

        public List<ListBookDto> Books { get; private set; }

        public void OnGet()
        {
            using (var context = new EfCoreContext())
            {
                BookService bookService = new(context);

                QueryOptions options = new()
                {
                    SearchParams = SearchParam,
                    OrderByOptions = OrderByOption,
                    FilterOptions = new FilterOptions
                    {
                        HasPriceOffer = HasPriceOffer
                    },
                    PageSize = (ushort)PageSize,
                    PageNumber = PageNumber
                };

                var result = bookService.GetListBooks(options);

                Books = result.Item1.ToList();
                PageNumber = result.Item2;
                NumberOfPages = result.Item3;
            }
        }
    }
}
