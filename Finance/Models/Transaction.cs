using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? TransactionTypeCode { get; set; }
}
