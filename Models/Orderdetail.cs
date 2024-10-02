using System;
using System.Collections.Generic;

namespace Book_Store.Models;

public partial class Orderdetail
{
    public int OrderDetailId { get; set; }

    public string? BookId { get; set; }

    public string? OrderId { get; set; }

    public int? Quantity { get; set; }

    public float? Price { get; set; }

    public float? TotalMoney { get; set; }
}
