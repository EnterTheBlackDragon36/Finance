using System;
using System.Collections.Generic;

namespace Finance.Models;

public partial class Party
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Details { get; set; }
}
