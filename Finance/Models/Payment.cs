using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? CardNumber { get; set; }

    public int? PayerPartyId { get; set; }

    public int? PayeeCounterpartyPartyId { get; set; }

    public int? PaymentMethodCode { get; set; }

    public int? PaymentFromCurrencyCode { get; set; }

    public int? PaymentToCurrencyCode { get; set; }

    public int? PaymentRequestId { get; set; }

    public int? PaymentStatusCode { get; set; }

    public int? PayeeBankSortCode { get; set; }

    public int? PayeeBankAccountNumber { get; set; }

    public string? PayeePayMobileNumber { get; set; }

    public DateTime? DateOfPayment { get; set; }

    public decimal? AmountOfPayment { get; set; }

    public string? OtherDetails { get; set; }

    public virtual CardNumber? CardNumberNavigation { get; set; }

    public virtual Party? PayeeCounterpartyParty { get; set; }

    public virtual Party? PayerParty { get; set; }

    public virtual RefCurrencyCode? PaymentFromCurrencyCodeNavigation { get; set; }

    public virtual RefPaymentMethod? PaymentMethodCodeNavigation { get; set; }

    public virtual PaymentRequest? PaymentRequest { get; set; }

    public virtual RefPaymentStatus? PaymentStatusCodeNavigation { get; set; }

    public virtual RefCurrencyCode? PaymentToCurrencyCodeNavigation { get; set; }
}
