using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    namespace Entities
    {
        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime PublishedOn { get; set; }
            [Column(TypeName = "decimal(8, 2)")] // precision of 8 and scale of 2: 123456.78
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
            public bool SoftDeleted { get; set; }

            public PriceOffer PriceOffer { get; set; }
            public ICollection<Review> Reviews { get; set; }
            public ICollection<BookAuthor> BookAuthor { get; set; }
        }
    }
}
