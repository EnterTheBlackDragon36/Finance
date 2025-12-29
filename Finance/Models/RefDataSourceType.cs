using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class RefDataSourceType
{
    public int DataSourceTypeCode { get; set; }

    public string? DataSourceTypeDescription { get; set; }

    public virtual ICollection<RefDataSource> RefDataSources { get; } = new List<RefDataSource>();
}
