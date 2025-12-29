using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class TransactionMessage
{
    public int Id { get; set; }

    public string? Message { get; set; }

    public Guid? AccountId { get; set; }

    public int? CounterpartyId { get; set; }

    public string? TransactionTypeCode { get; set; }
}
