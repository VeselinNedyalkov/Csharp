using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookServices : IBookServices
    {

        private readonly LibraryDbContext context;
        public BookServices(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task AddBookAsync(AddBooksViewModel model)
        {
            var newBook = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };

            await context.Books.AddAsync(newBook);
            await context.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(int bookId, string userId)
        {
            var user = await context.Users
              .Where(u => u.Id == userId)
              .Include(u => u.ApplicationUsersBooks)
              .FirstOrDefaultAsync();

            var book = await context.Books.FirstOrDefaultAsync(u => u.Id == bookId);

            if (!user.ApplicationUsersBooks.Any(m => m.BookId == bookId))
            {
                user.ApplicationUsersBooks.Add(new ApplicationUserBook()
                {
                    BookId = book.Id,
                    ApplicationUserId = user.Id,
                    Book = book,
                    ApplicationUser = user
                });

                await context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("The selected book is already in collection");
            }
        }

        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var books = await context.Books
                .Include(b => b.Category)
                .ToListAsync();

            return books.Select(b => new BookViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Description = b.Description,
                Author = b.Author,
                Rating = b.Rating,
                Category = b.Category.Name,
                ImageUrl = b.ImageUrl
            }); 
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            var result = await context.Categories.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<BookViewModel>> GetToCollectionAsync(string userId)
        {
            var user = await context.Users
               .Where(u => u.Id == userId)
               .Include(u => u.ApplicationUsersBooks)
               .ThenInclude(a => a.Book)
               .ThenInclude(b => b.Category)
               .FirstOrDefaultAsync();


           var result = user.ApplicationUsersBooks
                .Select(b => new BookViewModel()
                {
                    Id = b.BookId,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name,
                    Rating = b.Book.Rating,
                    ImageUrl = b.Book.ImageUrl
                });


            return result;
        }

        public async Task RemoveFromCollectionAsync(int bookId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.ApplicationUsersBooks)
                .FirstOrDefaultAsync();

            var book = user.ApplicationUsersBooks.FirstOrDefault(m => m.BookId == bookId);

            user.ApplicationUsersBooks.Remove(book);

            await context.SaveChangesAsync();

        }
    }
}
