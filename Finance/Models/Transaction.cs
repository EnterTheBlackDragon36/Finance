using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public Guid? AccountId { get; set; }

    public string? Type { get; set; }

    public DateTime? TransactionDate { get; set; }

    public virtual Account? Account { get; set; }
}
