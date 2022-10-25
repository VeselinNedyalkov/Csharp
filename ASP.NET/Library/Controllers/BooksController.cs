using Library.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Security.Claims;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBookServices bookServices;

        public BooksController(IBookServices _bookServices)
        {
            bookServices = _bookServices;
        }

        /// <summary>
        /// Select all books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var model = await bookServices.GetAllAsync();

            return View(model);
        }


        /// <summary>
        /// Add a new book 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Add()
        {
            var model = new AddBooksViewModel()
            {
                Categories = await bookServices.GetCategoryAsync()
            };

            return View(model);
        }


        /// <summary>
        /// post add method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Add(AddBooksViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookServices.AddBookAsync(model);

            return RedirectToAction(nameof(All));
        }


        /// <summary>
        /// Add book from all to collection
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

                await bookServices.AddBookToCollectionAsync(bookId, userId);
            }
            catch (Exception e)
            {
                var error = new ErrorViewModel
                {
                    RequestId = e.Message
                };

                return View("Error", error);
            }


            return RedirectToAction(nameof(All));
        }

        /// <summary>
        /// Show all books in collection
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Collection()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var model = await bookServices.GetToCollectionAsync(userId);

            return View("Mine", model);
        }

        /// <summary>
        /// Remoce book from colection
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await bookServices.RemoveFromCollectionAsync(bookId, userId);

            return RedirectToAction(nameof(Collection));
        }
    }
}
