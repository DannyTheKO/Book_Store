namespace Book_Store.Models;

public partial class Orderdetail
{
	public int OrderDetailId { get; set; }

	public int? BookId { get; set; }

	public int? OrderId { get; set; }

	public int? Quantity { get; set; }

	public float? Price { get; set; }

	public float? TotalMoney { get; set; }

	public virtual Book? Book { get; set; }

	public virtual OrderBook? Order { get; set; }
}
