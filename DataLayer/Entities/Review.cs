using System;

namespace DataLayer
{
    namespace Entities
    {
        public class Review
        {
            public int ReviewId { get; set; }
            public string ReviewerName { get; set; }
            public int NumStars { get; set; }
            public string Comment { get; set; }

            public int BookId { get; set; } // EF 5.0 can create this foreign key by itself. However, it is best practice to define it explicitly.
            public Book Book { get; set; }
        }
    }
}
