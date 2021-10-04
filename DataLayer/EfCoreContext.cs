using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DataLayer
{
    class EfCoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = BookStoreDb; Trusted_Connection = True; ")
            .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(new ServiceCollection()
            .AddLogging(builder => builder.AddConsole()
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                .BuildServiceProvider().GetService<ILoggerFactory>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookId, ba.AuthorId });

            // Seeding
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Refactoring", Description = "Improving the design of existing code", PublishedOn =new DateTime(1999, 7, 8), Price = 40 },
                new Book { BookId = 2, Title = "Patterns of Enterprise Application Architecture", Description = "Written in direct response to the stiff challenges", PublishedOn = new DateTime(2002, 11, 15), Price = 53 },
                new Book { BookId = 3, Title = "Domain - Driven Design", Description = "Linking business needs to software design", PublishedOn = new DateTime(2003, 8, 30), Price = 56 },
                new Book { BookId = 4, Title = "Quantum Networking", Description = "Entangled quantum networking provides faster - than - light data communications", PublishedOn = new DateTime(2057, 1, 1), Price = 220 }
                );

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, Name = "Martin Fowler"},
                new Author { AuthorId = 2, Name = "Eric Evans"},
                new Author { AuthorId = 3, Name = "Future Person"}
                );

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { BookId = 1, AuthorId = 1},
                new BookAuthor { BookId = 1, AuthorId = 2},
                new BookAuthor { BookId = 2, AuthorId = 1},
                new BookAuthor { BookId = 3, AuthorId = 2},
                new BookAuthor { BookId = 4, AuthorId = 3}
                );

            modelBuilder.Entity<Review>().HasData(
                new Review { ReviewId = 1, BookId = 1, Comment = "Great book", NumStars = 3 },
                new Review { ReviewId = 2, BookId = 1, Comment = "Boring book", NumStars = 1 }
                );

            // Show off
            //// Book/Review One-to-many relationship
            //modelBuilder.Entity<Review>()
            //    .HasOne(r => r.Book)
            //    .WithMany(b => b.Reviews)
            //    .HasForeignKey(r => r.ReviewId);
            //
            //// Book/PriceOffer One-to-one relationship
            //modelBuilder.Entity<Book>()
            //    .HasOne(b => b.PriceOffer)
            //    .WithOne(p => p.Book)
            //    .HasForeignKey<PriceOffer>(p => p.BookId);
            //
            //// Book/Author Many-to-many relationship
            //modelBuilder.Entity<BookAuthor>()
            //    .HasOne(ba => ba.Book)
            //    .WithMany(b => b.BookAuthor)
            //    .HasForeignKey(ba => ba.BookId);
            //
            //modelBuilder.Entity<BookAuthor>()
            //    .HasOne(ba => ba.Author)
            //    .WithMany(a => a.BookAuthor)
            //    .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
