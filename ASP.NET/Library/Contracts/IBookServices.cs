using Library.Data.Models;
using Library.Models;

namespace Library.Contracts
{
    public interface IBookServices
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();

        Task<IEnumerable<Category>> GetCategoryAsync();

        Task AddBookAsync(AddBooksViewModel model);

        Task AddBookToCollectionAsync(int bookId, string userId);

        Task<IEnumerable<BookViewModel>> GetToCollectionAsync(string userId);

        Task RemoveFromCollectionAsync(int bookId, string userId);
    }
}
