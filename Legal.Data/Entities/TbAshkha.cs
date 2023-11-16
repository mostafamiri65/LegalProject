using System;
using System.Collections.Generic;

namespace Legal.Data.Entities;

public partial class TbAshkha
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? NamePedar { get; set; }

    public string? Pisheh { get; set; }

    public string? Address { get; set; }

    public string? Tel { get; set; }

    public string? Mobile { get; set; }

    public string? Faks { get; set; }

    public string? Site { get; set; }

    public string? Email { get; set; }

    public byte? Jens { get; set; }

    public byte? NoehAshkhasCode { get; set; }

    public string? DateTavalod { get; set; }

    public string? Semat { get; set; }

    /// <summary>
    /// شناسه كاربر ثبت كننده ركورد
    /// </summary>
    public int? DeUserId { get; set; }

    /// <summary>
    /// شناسه مجموعه سازماني كاربر ثبت كننده ركورد
    /// </summary>
    public int? DeSetCode { get; set; }

    /// <summary>
    /// مرحله گردش كار
    /// </summary>
    public int? WfLevel { get; set; }

    /// <summary>
    /// آخرين شرح گردش كار
    /// </summary>
    public string? WfDscp { get; set; }

    /// <summary>
    /// مسير گردش كار
    /// </summary>
    public string? WfPath { get; set; }

    /// <summary>
    /// نوع رويداد
    /// </summary>
    public int ReplAct { get; set; }

    /// <summary>
    /// زمان رويداد
    /// </summary>
    public DateTime ReplTime { get; set; }

    /// <summary>
    /// مشخصه منحصر بفرد ركورد
    /// </summary>
    public Guid ReplUid { get; set; }

    /// <summary>
    /// شناسه كاربر ويرايش كننده ركورد
    /// </summary>
    public int? UpUserId { get; set; }

    /// <summary>
    /// شناسه مجموعه سازماني كاربر ثبت كننده ركورد
    /// </summary>
    public int? UpSetCode { get; set; }

    /// <summary>
    /// نام كامپيوتر كاربر ويرايش كننده ركورد
    /// </summary>
    public string? UpPc { get; set; }

    /// <summary>
    /// آي يي آدرس شبكه اي كاربر ويرايش كننده ركورد
    /// </summary>
    public string? UpIp { get; set; }

    /// <summary>
    /// مك آدرس شبكه اي كاربر ويرايش كننده ركورد
    /// </summary>
    public string? UpMac { get; set; }

    public string? CodeMeli { get; set; }

    public string? CodePosti { get; set; }
}
