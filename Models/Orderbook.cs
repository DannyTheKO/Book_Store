namespace Book_Store.Models;

public partial class OrderBook
{
	public int OrderId { get; set; }

	public DateTime? OrderDate { get; set; }

	public int? AccountId { get; set; }

	public string? ReceiveAddress { get; set; }

	public string? ReceivePhone { get; set; }

	public DateTime? OrderReceive { get; set; }

	public string? Note { get; set; }

	public string? Status { get; set; }

	public virtual Account? Account { get; set; }

	public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
