using System;
using System.Collections.Generic;

namespace Legal.Data.Entities;

public partial class TbShahrestan
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int OstanId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }

    public bool? IsOstan { get; set; }

    public virtual ICollection<TbNoyehParvandehMog> TbNoyehParvandehMogs { get; set; } = new List<TbNoyehParvandehMog>();
}
