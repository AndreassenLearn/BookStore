using System;
using System.Linq;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EagerLoadingFirstBookAndAuthorsAndReviews();
            EagerLoadingAllBooks();
            ExplicitLoadingFirstBook();
            ExplicitLoadingNumberOfReviews();
            SelectLoadingFirstBook();
        }

        #region Queries
        #region Eager loading
        private static void EagerLoadingFirstBookAndAuthorsAndReviews()
        {
            using (var context = new EfCoreContext())
            {
                Book book = context.Books
                    .OrderBy(b => b.BookId)
                    .Include(b => b.Reviews)
                    .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                    .AsNoTracking()
                    .FirstOrDefault();

                Console.WriteLine("Eager loading: First book and its authors and reviews");
                PrintBooks(book);
            }
        }

        private static void EagerLoadingAllBooks()
        {
            using (var context = new EfCoreContext())
            {
                var books = context.Books
                    .Include(b => b.BookAuthor)
                    .ThenInclude(ba => ba.Author)
                    .AsNoTracking()
                    .ToArray();

                Console.WriteLine("Eager loading: All books and their authors");
                PrintBooks(books);
            }

        }
        #endregion

        #region Explicit loading
        private static void ExplicitLoadingFirstBook()
        {
            using (var context = new EfCoreContext())
            {
                Book book = context.Books
                    .OrderBy(b => b.BookId)
                    .FirstOrDefault();

                Console.WriteLine("Explicit loading (1.0): First book");
                PrintBooks(book);

                context.Entry(book)
                    .Collection(b => b.BookAuthor)
                    .Query()
                    .Include(ba => ba.Author)
                    .Load();

                Console.WriteLine("Explicit loading (1.1): First book and its authors");
                PrintBooks(book);

                context.Entry(book)
                    .Collection(b => b.Reviews)
                    .Load();

                Console.WriteLine("Explicit loading (1.2): First book and its authors and reviews");
                PrintBooks(book);
            }
        }

        private static void ExplicitLoadingNumberOfReviews()
        {
            using (var context = new EfCoreContext())
            {
                Book book = context.Books
                    .OrderBy(b => b.BookId)
                    .FirstOrDefault();

                PrintBooks(book);

                var numberOfReviews = context.Entry(book)
                    .Collection(b => b.Reviews)
                    .Query().Count(); // Without Load() only the number of entries will be retrieved (less data - more efficient)

                Console.WriteLine("Explicit loading (2.0): Number of reviews in the first book (without retrieving them)");
                Console.WriteLine($"Number of reviews for this book: {numberOfReviews}");

                var reviews = context.Entry(book)
                    .Collection(b => b.Reviews)
                    .Query()
                    .Select(r => r.NumStars)
                    .ToList();
                
                Console.WriteLine("Explicit loading (2.1): Numbers of stars in reviews in the first book");
                foreach (int numStars in reviews)
                {
                    Console.WriteLine($"Stars: {numStars}");
                }
            }
        }
        #endregion

        #region Select loading
        private static void SelectLoadingFirstBook()
        {
            using (var context = new EfCoreContext())
            {
                var book = context.Books
                    .OrderBy(b => b.BookId)
                    .Select(b => new
                    {
                        Title = b.Title,
                        Price = b.Price,
                        NumberOfreviews = b.Reviews.Count()
                    })
                    .FirstOrDefault();

                Console.WriteLine("Select loading: Title, price, and number og reviews of the first book");
                Console.WriteLine($"Title: {book.Title}, Price: {book.Price}, Number of reviews: {book.NumberOfreviews}");
            }
        }
        #endregion
        #endregion

        static private void PrintBooks(params Book[] books)
        {
            foreach (Book book in books)
            {
                Console.WriteLine($"BookId: {book.BookId}, Title: {book.Title}, Price: {book.Price}");

                if (book.BookAuthor != null)
                {
                    foreach (BookAuthor bookAuthor in book.BookAuthor)
                    {
                        Console.WriteLine($"Author: {bookAuthor.Author.Name}");
                    }
                }

                if (book.Reviews != null)
                {
                    foreach (Review review in book.Reviews)
                    {
                        Console.WriteLine($"Stars: {review.NumStars}, Comment: {review.Comment}");
                    }
                }
            }
        }
    }
}
