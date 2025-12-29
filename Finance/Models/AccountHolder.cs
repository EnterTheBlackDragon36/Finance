using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class AccountHolder
{
    public int AccountHolderId { get; set; }

    public string? AccountHolderName { get; set; }

    public string? OtherDetails { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();
}
