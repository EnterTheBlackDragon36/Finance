using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class Bank
{
    public int Id { get; set; }

    public int? Accountnum { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public decimal? Accountbal { get; set; }

    public string? Accountcurrency { get; set; }

    public decimal? Withdrawal { get; set; }

    public decimal? Deposit { get; set; }
}
