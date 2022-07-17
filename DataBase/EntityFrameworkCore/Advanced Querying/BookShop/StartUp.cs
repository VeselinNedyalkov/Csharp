namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Z.EntityFramework.Plus;

    //using System;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //2. Age Restriction
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db, input));

            //3. Golden Books
            //Console.WriteLine(GetGoldenBooks(db));

            //4. Books by Price
            //Console.WriteLine(GetBooksByPrice(db));

            //5. Not Released In
            //int year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db, year)); 

            //6. Book Titles by Category
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db, input));

            //7. Released Before Date
            //string date = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, date));

            //8. Author Search
            //string input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

            //9. Book Search
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db, input));

            //10. Book Search by Author
            //string input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db,input));

            //11. Count Books
            //int input = int.Parse(Console.ReadLine());
            //Console.WriteLine(CountBooks(db,input));

            //12. Total Book Copies
            //Console.WriteLine(CountCopiesByAuthor(db));

            //13. Profit by Category
            Console.WriteLine(GetTotalProfitByCategory(db));

            //14. Most Recent Books
            Console.WriteLine(GetMostRecentBooks(db));

            //15. Increase Prices
            IncreasePrices(db);

            //16. Remove Books
            RemoveBooks(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var stringRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == stringRestriction)
                .Select(b => b.Title)
                .OrderBy(Title => Title)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var booksRestrictions = Enum.Parse<EditionType>("Gold");

            var goldBooks = context.Books
                .Where(b => b.Copies < 5000 && b.EditionType == booksRestrictions)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, goldBooks);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var bookByPrice = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookPrice = b.Price,
                })
                .OrderByDescending(x => x.BookPrice)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in bookByPrice)
            {
                sb.AppendLine($"{book.BookTitle} - ${book.BookPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<string> books = context.Books
                .Where(x => x.BookCategories.Any(x => categories.Contains(x.Category.Name.ToLower())))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var result = context.Books
                .Where(x => x.ReleaseDate.Value < targetDate)
                .Select(x => new
                {
                    BookTitle = x.Title,
                    BookEdition = x.EditionType,
                    BookPrice = x.Price,
                    DateRealse = x.ReleaseDate,
                })
                .OrderByDescending(x => x.DateRealse)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var book in result)
            {
                sb.AppendLine($"{book.BookTitle} - {book.BookEdition} - ${book.BookPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var result = context.Authors
                .Where(b => b.FirstName.EndsWith(input))
                .Select(b => new
                {
                    FirstName = b.FirstName,
                    LastName = b.LastName,
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var author in result)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var result = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var b in result)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var result = context.Books
                .Include(x => x.Author)
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    BookId = b.BookId,
                    BookTitle = b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName,
                })
                .OrderBy(x => x.BookId)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var b in result)
            {
                sb.AppendLine($"{b.BookTitle} ({b.AuthorFirstName} {b.AuthorLastName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var resut = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .ToArray();

            return resut.Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var result = context.Authors
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Count = x.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.Count)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var a in result)
            {
                sb.AppendLine($"{a.FirstName} {a.LastName} - {a.Count}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = context.Categories
                .Select(x => new
                {
                    CategorieName = x.Name,
                    Profit = x.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)

                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.CategorieName)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var a in result)
            {
                sb.AppendLine($"{a.CategorieName} ${a.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var result = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    Name = x.Name,
                    ResultBooks = x.CategoryBooks.Select(b => new
                    {
                        Title = b.Book.Title,
                        RDate = b.Book.ReleaseDate.Value.Year
                    })
                    .OrderByDescending(c => c.RDate)
                    .Take(3)
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var c in result)
            {
                sb.AppendLine($"--{c.Name}");

                foreach (var item in c.ResultBooks)
                {
                    sb.AppendLine($"{item.Title} ({item.RDate})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var results = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToArray();

            int increasePrice = 5;

            foreach (var b in results)
            {
                b.Price += increasePrice;
            }

            context.SaveChanges();


            //One more solution not working in Judge, working locally

            //context.Books.Where(x => x.ReleaseDate.Value.Year < 2010)
            //     .Update(x => new Book { Price = x.Price + 5 });
        }

        public static int RemoveBooks(BookShopContext context)
        {
            return context.Books.Where(x => x.Copies < 4200).Delete();
        }
    }
}
