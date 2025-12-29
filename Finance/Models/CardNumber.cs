using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class CardNumber
{
    public int CardNumber1 { get; set; }

    public int? AccountId { get; set; }

    public string? CardHolderName { get; set; }

    public DateTime? ExpirDate { get; set; }

    public string? OtherDetails { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();
}
