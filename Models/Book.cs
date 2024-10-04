using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Book_Store.Models;

public partial class Book
{
    [DisplayName("Book ID")]
    public string BookId { get; set; } = null!;

    [DisplayName("Category ID")]
    public int? CategoryId { get; set; }

    [DisplayName("Publisher ID")]
    public int? PublisherId { get; set; }

    [DisplayName("Book Title")]
    public string? Title { get; set; }

    [DisplayName("Author")]
    public string? Author { get; set; }

    [DisplayName("Release Date")]
    public int? Release { get; set; }

    [DisplayName("Price")]
    public float? Price { get; set; }

    [DisplayName("Description")]
    public string? Description { get; set; }

    [DisplayName("Picture")]
    public string? Picture { get; set; }
}
