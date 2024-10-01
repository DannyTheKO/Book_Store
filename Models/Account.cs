using System;
using System.Collections.Generic;

namespace Book_Store.Models;

public partial class Account
{
    public string AccountId { get; set; } = null!;

    public string? Usernane { get; set; }

    public string? Password { get; set; }

    public string? FullName { get; set; }

    public string? Picture { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public ulong? IsAdmin { get; set; }

    public ulong? Active { get; set; }
}
