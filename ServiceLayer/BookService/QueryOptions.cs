using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ServiceLayer.BookService.BookSort;

namespace ServiceLayer.BookService
{
    public class QueryOptions
    {
        public string SearchParams { get; set; }
        public OrderByOptions OrderByOptions { get; set; }
        public FilterOptions FilterOptions { get; set; }

        public ushort PageSize { get; set; }
        public ushort PageNumber { get; set; }
        public ushort NumberOfPages { get; private set; }
    }
}
