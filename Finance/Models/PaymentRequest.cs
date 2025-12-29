using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class PaymentRequest
{
    public int PaymentRequestId { get; set; }

    public int? DataSourceCode { get; set; }

    public string? OtherDetails { get; set; }

    public virtual RefDataSource? DataSourceCodeNavigation { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();
}
