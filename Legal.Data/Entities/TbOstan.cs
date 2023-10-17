using System;
using System.Collections.Generic;

namespace Legal.Data.Entities;

public partial class TbOstan
{
    public int Id { get; set; }

    public int? Code { get; set; }

    public string? Title { get; set; }

    public int RegionId { get; set; }

    public DateTime CreateDate { get; set; }

    public long? CreateBy { get; set; }

    public string? CreateIp { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public long? ModifiedBy { get; set; }

    public string? ModifiedIp { get; set; }

    public Guid? Gid { get; set; }

    public virtual TbRegion Region { get; set; } = null!;
}
