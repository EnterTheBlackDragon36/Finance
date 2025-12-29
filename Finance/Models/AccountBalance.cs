using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class AccountBalance
{
    public int Id { get; set; }

    public Guid? AccountId { get; set; }

    public decimal? CurrentBalance { get; set; }

    public decimal? PreviousBalance { get; set; }

    public decimal? NewBalance { get; set; }

    public DateTime? TransactionDate { get; set; }
}
