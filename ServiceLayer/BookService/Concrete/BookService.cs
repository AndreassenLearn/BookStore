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

        public IQueryable<ListBookDto> GetListBooks()
        {
            return _context.Books
                .AsNoTracking()
                .MapListBookToDto();
        }
    }
}
