using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models;

public partial class Book
{
	[DisplayName("ID")]
	public int BookId { get; set; }

	[DisplayName("Category ID")]
	public int? CategoryId { get; set; }

	[DisplayName("Publisher ID")]
	public int? PublisherId { get; set; }

	[DisplayName("Title")]
	public string? Title { get; set; }

	[DisplayName("Author")]
	public string? Author { get; set; }

	[DisplayName("Release")]
	public int? Release { get; set; }

	[DisplayName("Price")]
	public float? Price { get; set; }

	[DisplayName("Description")]
	[MaxLength(1024)]
	public string? Description { get; set; }

	[DisplayName("Picture")]
	public string? Picture { get; set; }

	public virtual Category? Category { get; set; }

	public virtual ICollection<Orderdetail> OrderDetail { get; set; } = new List<Orderdetail>();

	public virtual Publisher? Publisher { get; set; }
}
