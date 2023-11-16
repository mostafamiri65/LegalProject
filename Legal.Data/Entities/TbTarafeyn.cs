using System;
using System.Collections.Generic;

namespace Legal.Data.Entities;

public partial class TbTarafeyn
{
    public int Id { get; set; }

    public int? ParvandehId { get; set; }

    public int? AshkhasId { get; set; }

    public DateTime? Mdate { get; set; }

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

    public byte? Khahan { get; set; }

    public byte? Vakhilkhahan { get; set; }
}
