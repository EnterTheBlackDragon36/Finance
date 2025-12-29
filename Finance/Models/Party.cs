using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class Party
{
    public int PartyId { get; set; }

    public int? PartyTypeCode { get; set; }

    public string? PartyName { get; set; }

    public string? PartyPhone { get; set; }

    public string? PartyEmail { get; set; }

    public string? OtherDetails { get; set; }

    public virtual RefPartyType? PartyTypeCodeNavigation { get; set; }

    public virtual ICollection<Payment> PaymentPayeeCounterpartyParties { get; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentPayerParties { get; } = new List<Payment>();
}
