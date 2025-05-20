using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class AccountType
{
    public int Id { get; set; }

    public string? AccountTypeCode { get; set; }

    public string? Account { get; set; }

    public string? AccountTypeDescription { get; set; }
}
