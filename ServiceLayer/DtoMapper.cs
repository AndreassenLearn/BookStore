using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.BookService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class DtoMapper
    {
        public static IQueryable<ListBookDto> MapListBookToDto(this IQueryable<Book> books)
        {
            return books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.PriceOffer)
                .Select(b => 
            new ListBookDto
            {
                BookId = b.BookId,
                Title = b.Title,
                AuthorNames = b.BookAuthors.Select(ba => ba.Author.Name).ToList(),
                AverageRating = b.Reviews.Average(r => r.NumStars),
                NumOfReviews = b.Reviews.Count(),
                Price = b.Price,
                NewPrice = b.PriceOffer.NewPrice,
                PromtionalText = b.PriceOffer.PromtionalText
            });
        }

        public static DetailsBookDto MapDetailsBookDto(this Book book)
        {
            if (book == null)
            {
                return new DetailsBookDto();
            }
            
            return new DetailsBookDto
            {
                BookId = book.BookId,
                Title = book.Title
            };
        }
    }
}
