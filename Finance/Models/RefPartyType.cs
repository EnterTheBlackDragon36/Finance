using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class RefPartyType
{
    public int PartyTypeCode { get; set; }

    public string? PartyTypeDescription { get; set; }

    public virtual ICollection<Party> Parties { get; } = new List<Party>();
}
