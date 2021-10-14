using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.BookService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.Conrete
{
    public class BookService
    {
        private readonly EfCoreContext _context;
        public BookService(EfCoreContext context)
        {
            _context = context;
        }

        public Tuple<IQueryable<ListBookDto>, ushort, ushort> GetListBooks(QueryOptions queryOptions)
        {
            ushort pageNumber = queryOptions.PageNumber;
            
            IQueryable<ListBookDto> books = _context.Books
                .AsNoTracking()
                .MapListBookToDto()
                .SearchFor(queryOptions.SearchParams)
                .Filter(queryOptions.FilterOptions)
                .OrderBooksBy(queryOptions.OrderByOptions)
                .Page(ref pageNumber, queryOptions.PageSize, out ushort numberOfPages);

            return Tuple.Create(books, pageNumber, numberOfPages);
        }

        public DetailsBookDto GetDetailsBook(int? bookId) =>
            _context.Books
                .Where(b => b.BookId == bookId)
                .FirstOrDefault()
                .MapDetailsBookDto();

        public int Count() =>
            _context.Books.Count();
    }
}
