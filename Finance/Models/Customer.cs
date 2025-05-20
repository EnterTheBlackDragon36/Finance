using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class Customer
{
    public int Id { get; set; }

    public Guid CustomerId { get; set; }

    public int? CustomertypeId { get; set; }

    public string? Firstname { get; set; }

    public string? Middlename { get; set; }

    public string? Lastname { get; set; }

    public string? Suffix { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? DateBecameCustomer { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual CustomerType? Customertype { get; set; }
}
