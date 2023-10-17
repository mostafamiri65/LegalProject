using System;
using System.Collections.Generic;

namespace Legal.Data.Entities;

public partial class TbRegion
{
    public int Id { get; set; }

    public string? Dscp { get; set; }

    public int? Code { get; set; }

    public int? PrNum { get; set; }

    public string? Name { get; set; }

    public string? Last { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }

    public virtual ICollection<TbOstan> TbOstans { get; set; } = new List<TbOstan>();
}
