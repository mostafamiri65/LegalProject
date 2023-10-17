using System;
using System.Collections.Generic;

namespace Legal.Data.Entities;

public partial class ApplicationLog
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public DateTime DoingDate { get; set; }

    public string? TableName { get; set; }

    public string DoingDescription { get; set; } = null!;
}
