using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class TransactionType
{
    public string TransactionTypeCode { get; set; } = null!;

    public string? Transactiontype1 { get; set; }

    public string? Description { get; set; }
}
