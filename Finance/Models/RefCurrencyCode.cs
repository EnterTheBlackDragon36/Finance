using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class RefCurrencyCode
{
    public int CurrencyCode { get; set; }

    public string? CurrencyCodeName { get; set; }

    public virtual ICollection<Payment> PaymentPaymentFromCurrencyCodeNavigations { get; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentPaymentToCurrencyCodeNavigations { get; } = new List<Payment>();
}
