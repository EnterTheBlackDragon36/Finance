using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class RefPaymentStatus
{
    public int PaymentStatusCode { get; set; }

    public string? PaymentStatusDescription { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();
}
