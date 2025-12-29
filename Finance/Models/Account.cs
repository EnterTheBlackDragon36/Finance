using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public long? AccountNumber { get; set; }

    public int? AccountHolderId { get; set; }

    public string? AccountName { get; set; }

    public decimal? CurrentBalance { get; set; }

    public string? OtherDetails { get; set; }

    public DateTime? DateOpened { get; set; }

    public DateTime? DateClosed { get; set; }

    public DateTime? LastActivity { get; set; }

    public virtual AccountHolder? AccountHolder { get; set; }

    public virtual ICollection<CardNumber> CardNumbers { get; } = new List<CardNumber>();
}
