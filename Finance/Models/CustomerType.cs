using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class CustomerType
{
    public int Id { get; set; }

    public string CustomerTypeCode { get; set; } = null!;

    public string? Customertype1 { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();
}
