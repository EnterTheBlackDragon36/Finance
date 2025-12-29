using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class RefTransactionType
{
    public int TransactionTypeCode { get; set; }

    public string? TransactionTypeDescription { get; set; }
}
