using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}