using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstant.CategoryConstant;

namespace Library.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxlength)]
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
