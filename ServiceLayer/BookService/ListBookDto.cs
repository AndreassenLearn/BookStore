using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BookService
{
    public class ListBookDto
    {
        public string Title { get; set; }
        public ICollection<string> AuthorNames { get; set; }
        public double? AverageRating { get; set; }
        public int NumOfReviews { get; set; }
        public decimal Price { get; set; }
        public decimal? NewPrice { get; set; }
        public string PromtionalText { get; set; }
    }
}
