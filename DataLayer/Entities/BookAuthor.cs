using System;
using System.Collections.Generic;

namespace DataLayer
{
    namespace Entities
    {
        public class BookAuthor
        {
            public int BookId { get; set; }
            public Book Book { get; set; }

            public int AuthorId { get; set; }
            public Author Author { get; set; }

            public byte Other { get; set; }
        }
    }
}
