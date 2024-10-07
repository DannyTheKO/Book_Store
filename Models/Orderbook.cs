using System;
using System.Collections.Generic;

namespace Book_Store.Models;

public partial class Orderbook
{
    public string OrderId { get; set; } = null!;

    public DateTime? OrderDate { get; set; }

    public string? AccountId { get; set; }

    public string? ReceiveAddress { get; set; }

    public string? ReceivePhone { get; set; }

    public DateTime? OrderReceive { get; set; }

    public string? Note { get; set; }

    public string? Status { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
