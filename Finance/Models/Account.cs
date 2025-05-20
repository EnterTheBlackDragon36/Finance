using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class Account
{
    public int Id { get; set; }

    public Guid AccountId { get; set; }

    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? DateOpened { get; set; }

    public DateTime? DateClosed { get; set; }

    public DateTime? LastActivity { get; set; }

    public long AccountNum { get; set; }

    public virtual ICollection<BankCard> BankCards { get; } = new List<BankCard>();

    public virtual Customer Customer { get; set; } = null!;
}
