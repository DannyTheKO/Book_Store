using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Book_Store.Models
{
    public enum ActiveStatus
    {
        N, Y
    }

    public class Book
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Author { get; set; }

        [Required]
        public required string Publisher { get; set; }

        public int Avaliable { get; set; }

        public decimal Price { get; set; }

        public DateOnly CreateOn { get; set; }

        public ActiveStatus IsActive { get; set; } = ActiveStatus.N; // Set the default value here

        public int GenreId { get; set; }
    }
}
