using System;
using System.Collections.Generic;

namespace Book_Store.Models;

public partial class Book
{
    public string BookId { get; set; } = null!;

    public int? CategoryId { get; set; }

    public int? PublisherId { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public int? Release { get; set; }

    public float? Price { get; set; }

    public string? Description { get; set; }

    public string? Picture { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual Publisher? Publisher { get; set; }
}
