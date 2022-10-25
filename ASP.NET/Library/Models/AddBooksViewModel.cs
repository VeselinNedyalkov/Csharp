using Library.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstant.BookConstant;

namespace Library.Models
{
    public class AddBooksViewModel
    {
        [Required]
        [StringLength(TitleMaxLenght, MinimumLength = TitleMinLenght)]
        public string Title { get; set; }

        [Required]
        [StringLength(AuthorMaxLenght , MinimumLength = AuthorMinLenght)]
        public string Author { get; set; }

        [Required]
        [StringLength(DescriptionMaxLenght , MinimumLength = DescriptionMinLenght)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
