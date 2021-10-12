﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(EfCoreContext))]
    partial class EfCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            Name = "Martin Fowler"
                        },
                        new
                        {
                            AuthorId = 2,
                            Name = "Eric Evans"
                        },
                        new
                        {
                            AuthorId = 3,
                            Name = "Future Person"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<DateTime>("PublishedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Description = "Improving the design of existing code",
                            Price = 40m,
                            PublishedOn = new DateTime(1999, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SoftDeleted = false,
                            Title = "Refactoring"
                        },
                        new
                        {
                            BookId = 2,
                            Description = "Written in direct response to the stiff challenges",
                            Price = 53m,
                            PublishedOn = new DateTime(2002, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SoftDeleted = false,
                            Title = "Patterns of Enterprise Application Architecture"
                        },
                        new
                        {
                            BookId = 3,
                            Description = "Linking business needs to software design",
                            Price = 56m,
                            PublishedOn = new DateTime(2003, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SoftDeleted = false,
                            Title = "Domain - Driven Design"
                        },
                        new
                        {
                            BookId = 4,
                            Description = "Entangled quantum networking provides faster - than - light data communications",
                            Price = 220m,
                            PublishedOn = new DateTime(2057, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SoftDeleted = false,
                            Title = "Quantum Networking"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<byte>("Other")
                        .HasColumnType("tinyint");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthor");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            Other = (byte)0
                        },
                        new
                        {
                            BookId = 1,
                            AuthorId = 2,
                            Other = (byte)0
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 1,
                            Other = (byte)0
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 2,
                            Other = (byte)0
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 3,
                            Other = (byte)0
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.PriceOffer", b =>
                {
                    b.Property<int>("PriceOfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<decimal>("NewPrice")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("PromtionalText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PriceOfferId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("PriceOffers");
                });

            modelBuilder.Entity("DataLayer.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumStars")
                        .HasColumnType("int");

                    b.Property<string>("ReviewerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.HasIndex("BookId");

                    b.ToTable("Review");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            BookId = 1,
                            Comment = "Great book",
                            NumStars = 3
                        },
                        new
                        {
                            ReviewId = 2,
                            BookId = 1,
                            Comment = "Boring book",
                            NumStars = 1
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.BookAuthor", b =>
                {
                    b.HasOne("DataLayer.Entities.Author", "Author")
                        .WithMany("BookAuthor")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("DataLayer.Entities.PriceOffer", b =>
                {
                    b.HasOne("DataLayer.Entities.Book", "Book")
                        .WithOne("PriceOffer")
                        .HasForeignKey("DataLayer.Entities.PriceOffer", "BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("DataLayer.Entities.Review", b =>
                {
                    b.HasOne("DataLayer.Entities.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("DataLayer.Entities.Author", b =>
                {
                    b.Navigation("BookAuthor");
                });

            modelBuilder.Entity("DataLayer.Entities.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("PriceOffer");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
