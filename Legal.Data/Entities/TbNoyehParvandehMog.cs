using System;
using System.Collections.Generic;

namespace Legal.Data.Entities;

public partial class TbNoyehParvandehMog
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? ShahrestanId { get; set; }

    public virtual TbShahrestan? Shahrestan { get; set; }
}
