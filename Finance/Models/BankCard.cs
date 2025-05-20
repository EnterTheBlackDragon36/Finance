using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class BankCard
{
    public int Id { get; set; }

    public Guid? AccountId { get; set; }

    public string? Nameoncard { get; set; }

    public string? Cardnumber { get; set; }

    public string? Cardtype { get; set; }

    public bool? Securitychip { get; set; }

    public int? Csv { get; set; }

    public DateTime? Expirationdate { get; set; }

    public int? Expirationmonth { get; set; }

    public int? Expirationyear { get; set; }

    public DateTime? Issuedate { get; set; }

    public virtual Account? Account { get; set; }
}
