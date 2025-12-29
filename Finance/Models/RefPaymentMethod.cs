using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class RefPaymentMethod
{
    public int PaymentMethodCode { get; set; }

    public string? PaymentMethodName { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();
}
