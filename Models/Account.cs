namespace Book_Store.Models;

public partial class Account
{
	public int AccountId { get; set; }

	public string? Username { get; set; }

	public string? Password { get; set; }

	public string? FullName { get; set; }

	public string? Picture { get; set; }

	public string? Email { get; set; }

	public string? Address { get; set; }

	public string? Phone { get; set; }

	public string? IsAdmin { get; set; }

	public string? Active { get; set; }

	public virtual ICollection<OrderBook> OrderBook { get; set; } = new List<OrderBook>();
}
