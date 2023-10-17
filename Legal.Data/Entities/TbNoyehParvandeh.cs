using System;
using System.Collections.Generic;

namespace Legal.Data.Entities;

public partial class TbNoyehParvandeh
{
    public byte Code { get; set; }

    public string Title { get; set; } = null!;

    public string? KhahanBadvi { get; set; }

    public string? KandehBadvi { get; set; }

    public string? KhahanTajdid { get; set; }

    public string? KhandehTajdid { get; set; }
}
