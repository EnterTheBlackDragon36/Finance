using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class RefDataSource
{
    public int DataSourceCode { get; set; }

    public int? DataSourceTypeCode { get; set; }

    public string? DataSourceName { get; set; }

    public virtual RefDataSourceType? DataSourceTypeCodeNavigation { get; set; }

    public virtual ICollection<PaymentRequest> PaymentRequests { get; } = new List<PaymentRequest>();
}
