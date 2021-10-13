using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.BookService
{
    public static class BookSort
    {
        public enum OrderByOptions
        {
            [Display(Name = "Name (Ascending)")]
            ByNameAsc = 0,
            [Display(Name = "Name (Descending)")]
            ByNameDesc,
            [Display(Name = "Price (Ascending)")]
            ByPriceAsc,
            [Display(Name = "Price (Descending)")]
            ByPriceDesc
        }

        public static IQueryable<ListBookDto> OrderBooksBy(this IQueryable<ListBookDto> locomotives, OrderByOptions orderByOptions) => orderByOptions switch
        {
            OrderByOptions.ByNameAsc => locomotives.OrderBy(l => l.Title),
            OrderByOptions.ByNameDesc => locomotives.OrderByDescending(l => l.Title),
            OrderByOptions.ByPriceAsc => locomotives.OrderBy(l => l.Price),
            OrderByOptions.ByPriceDesc => locomotives.OrderByDescending(l => l.Price),
            _ => throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null),
        };

        public static IQueryable<ListBookDto> SearchFor(this IQueryable<ListBookDto> books, string searchParams) => books
                .Where(b => string.IsNullOrEmpty(searchParams)
                || b.Title.Contains(searchParams)
                || b.AuthorNames.Where(ab => ab.Contains(searchParams)).Any());

        public static IQueryable<ListBookDto> Filter(this IQueryable<ListBookDto> books, FilterOptions filterOptions) => books
            .Where(b => (!filterOptions.HasPriceOffer || b.NewPrice.HasValue));

        public static IQueryable<T> Page<T>(this IQueryable<T> query, ref ushort pageNumber, ushort pageSize, out ushort numberOfPages)
        {
            if (pageSize == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size cannot be zero.");
            }

            numberOfPages = (ushort)Math.Ceiling((double)query.Count() / pageSize);
            pageNumber = Math.Min(Math.Max((ushort)1, pageNumber), numberOfPages);

            if (pageNumber > 1)
            {
                query = query.Skip((pageNumber - 1) * pageSize);
            }

            return query.Take(pageSize);
        }
    }
}
