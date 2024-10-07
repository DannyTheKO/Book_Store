using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Models;

public partial class Book
{
    [DisplayName("ID")]
    public string BookId { get; set; } = null!;

    [DisplayName("Category ID")]
    public int? CategoryId { get; set; }

    [DisplayName("Publisher ID")]
    public int? PublisherId { get; set; }

    [DisplayName("Title")]
    public string? Title { get; set; }

    [DisplayName("Author")]
    public string? Author { get; set; }

    [DisplayName("Release Year")]
    public int? Release { get; set; }

    [DisplayName("Price")]
    public float? Price { get; set; }

    [DisplayName("Description")]
    public string? Description { get; set; }

    [DisplayName("Picture")]
    public string? Picture { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual Publisher? Publisher { get; set; }
}
