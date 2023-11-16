using System;
using System.Collections.Generic;

namespace Legal.Data.Entities;

public partial class TbNoyehParvandehMarja
{
    public int Id { get; set; }

    public string? Titel { get; set; }

    public int? Lev { get; set; }

    public int? NoyehParvandehCode { get; set; }

    public virtual TbNoyehParvandeh? NoyehParvandehCodeNavigation { get; set; }
}
