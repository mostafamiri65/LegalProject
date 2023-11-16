using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Legal.Data.Entities;

public partial class LowDbContext : DbContext
{
    public LowDbContext()
    {
    }

    public LowDbContext(DbContextOptions<LowDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationLog> ApplicationLogs { get; set; }

    public virtual DbSet<TbAshkha> TbAshkhas { get; set; }

    public virtual DbSet<TbKhahanTitle> TbKhahanTitles { get; set; }

    public virtual DbSet<TbNoyehParvandeh> TbNoyehParvandehs { get; set; }

    public virtual DbSet<TbNoyehParvandehMarja> TbNoyehParvandehMarjas { get; set; }

    public virtual DbSet<TbNoyehParvandehMog> TbNoyehParvandehMogs { get; set; }

    public virtual DbSet<TbOstan> TbOstans { get; set; }

    public virtual DbSet<TbParvandeh> TbParvandehs { get; set; }

    public virtual DbSet<TbParvandehBk> TbParvandehBks { get; set; }

    public virtual DbSet<TbPrDasteh> TbPrDastehs { get; set; }

    public virtual DbSet<TbRegion> TbRegions { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbShahrestan> TbShahrestans { get; set; }

    public virtual DbSet<TbTarafeyn> TbTarafeyns { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbUserRole> TbUserRoles { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=192.168.1.37;Database=LowDb;User Id = sa;Password = M13961221@;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_100_CI_AS");

        modelBuilder.Entity<ApplicationLog>(entity =>
        {
            entity.ToTable("ApplicationLog");

            entity.Property(e => e.DoingDescription).HasMaxLength(500);
            entity.Property(e => e.TableName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbAshkha>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CodeMeli)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodePosti)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateTavalod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DeSetCode)
                .HasComment("شناسه مجموعه سازماني كاربر ثبت كننده ركورد")
                .HasColumnName("DE_SetCode");
            entity.Property(e => e.DeUserId)
                .HasComment("شناسه كاربر ثبت كننده ركورد")
                .HasColumnName("DE_UserId");
            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Faks).HasMaxLength(15);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Mobile).HasMaxLength(15);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NamePedar).HasMaxLength(50);
            entity.Property(e => e.Pisheh).HasMaxLength(50);
            entity.Property(e => e.ReplAct)
                .HasDefaultValueSql("((2))")
                .HasComment("نوع رويداد")
                .HasColumnName("Repl_Act");
            entity.Property(e => e.ReplTime)
                .HasDefaultValueSql("(getdate())")
                .HasComment("زمان رويداد")
                .HasColumnType("datetime")
                .HasColumnName("Repl_Time");
            entity.Property(e => e.ReplUid)
                .HasDefaultValueSql("(newid())")
                .HasComment("مشخصه منحصر بفرد ركورد")
                .HasColumnName("Repl_UID");
            entity.Property(e => e.Semat).HasMaxLength(100);
            entity.Property(e => e.Site).HasMaxLength(30);
            entity.Property(e => e.Tel).HasMaxLength(15);
            entity.Property(e => e.UpIp)
                .HasMaxLength(50)
                .HasComment("آي يي آدرس شبكه اي كاربر ويرايش كننده ركورد")
                .HasColumnName("UP_IP");
            entity.Property(e => e.UpMac)
                .HasMaxLength(50)
                .HasComment("مك آدرس شبكه اي كاربر ويرايش كننده ركورد")
                .HasColumnName("UP_MAC");
            entity.Property(e => e.UpPc)
                .HasMaxLength(200)
                .HasComment("نام كامپيوتر كاربر ويرايش كننده ركورد")
                .HasColumnName("Up_PC");
            entity.Property(e => e.UpSetCode)
                .HasComment("شناسه مجموعه سازماني كاربر ثبت كننده ركورد")
                .HasColumnName("Up_SetCode");
            entity.Property(e => e.UpUserId)
                .HasComment("شناسه كاربر ويرايش كننده ركورد")
                .HasColumnName("Up_UserId");
            entity.Property(e => e.WfDscp)
                .HasMaxLength(200)
                .HasComment("آخرين شرح گردش كار")
                .HasColumnName("WF_Dscp");
            entity.Property(e => e.WfLevel)
                .HasComment("مرحله گردش كار")
                .HasColumnName("WF_Level");
            entity.Property(e => e.WfPath)
                .HasMaxLength(1000)
                .HasComment("مسير گردش كار")
                .HasColumnName("WF_Path");
        });

        modelBuilder.Entity<TbKhahanTitle>(entity =>
        {
            entity.ToTable("TbKhahanTitle");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<TbNoyehParvandeh>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("TbNoyehParvandeh");

            entity.Property(e => e.Code).ValueGeneratedNever();
            entity.Property(e => e.KandehBadvi).HasMaxLength(100);
            entity.Property(e => e.KhahanBadvi)
                .HasMaxLength(100)
                .HasColumnName("khahanBadvi");
            entity.Property(e => e.KhahanTajdid)
                .HasMaxLength(100)
                .HasColumnName("khahanTajdid");
            entity.Property(e => e.KhandehTajdid)
                .HasMaxLength(100)
                .HasColumnName("khandehTajdid");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<TbNoyehParvandehMarja>(entity =>
        {
            entity.ToTable("TbNoyehParvandehMarja");

            entity.Property(e => e.Titel).HasMaxLength(100);

            entity.HasOne(d => d.NoyehParvandehCodeNavigation).WithMany(p => p.TbNoyehParvandehMarjas)
                .HasForeignKey(d => d.NoyehParvandehCode)
                .HasConstraintName("FK_TbNoyehParvandehMarja_TbNoyehParvandeh");
        });

        modelBuilder.Entity<TbNoyehParvandehMog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TbMarjaMog");

            entity.ToTable("TbNoyehParvandehMog");

            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Shahrestan).WithMany(p => p.TbNoyehParvandehMogs)
                .HasForeignKey(d => d.ShahrestanId)
                .HasConstraintName("FK_TbMarjaMog_TbShahrestan");
        });

        modelBuilder.Entity<TbOstan>(entity =>
        {
            entity.ToTable("TbOstan");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Region).WithMany(p => p.TbOstans)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbOstan_TbRegion");
        });

        modelBuilder.Entity<TbParvandeh>(entity =>
        {
            entity.ToTable("TbParvandeh");

            entity.Property(e => e.DateIjad)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DateRay)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EjraDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HagVekalat).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HazinehDadresi).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Jaryan).HasDefaultValueSql("((1))");
            entity.Property(e => e.Khahan).HasColumnName("khahan");
            entity.Property(e => e.Khasteh).HasMaxLength(400);
            entity.Property(e => e.Lah).HasDefaultValueSql("((1))");
            entity.Property(e => e.MakhtoomeDalil).HasMaxLength(150);
            entity.Property(e => e.MakhtoomeDate).HasMaxLength(20);
            entity.Property(e => e.Maly).HasDefaultValueSql("((1))");
            entity.Property(e => e.MarjaName).HasMaxLength(200);
            entity.Property(e => e.RakedDalil).HasMaxLength(150);
            entity.Property(e => e.RakedDate).HasMaxLength(20);
            entity.Property(e => e.RayTajdidDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Search1).HasMaxLength(50);
            entity.Property(e => e.Search2).HasMaxLength(50);
            entity.Property(e => e.ShParvandeh).HasMaxLength(50);
            entity.Property(e => e.ShParvandeh24)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.TajdidDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TajdidHagVekalat).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TajdidHazinehDadresi).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TajdidKhahan)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
        });

        modelBuilder.Entity<TbParvandehBk>(entity =>
        {
            entity.ToTable("TbParvandehBk");

            entity.Property(e => e.DateIjad)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DateRay)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EjraDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HagVekalat).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.HazinehDadresi).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Khahan).HasColumnName("khahan");
            entity.Property(e => e.Khasteh).HasMaxLength(400);
            entity.Property(e => e.MakhtoomeDalil).HasMaxLength(150);
            entity.Property(e => e.MakhtoomeDate).HasMaxLength(20);
            entity.Property(e => e.MarjaName).HasMaxLength(200);
            entity.Property(e => e.RakedDalil).HasMaxLength(150);
            entity.Property(e => e.RakedDate).HasMaxLength(20);
            entity.Property(e => e.RayTajdidDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Search1).HasMaxLength(50);
            entity.Property(e => e.Search2).HasMaxLength(50);
            entity.Property(e => e.ShParvandeh).HasMaxLength(50);
            entity.Property(e => e.ShParvandeh24)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.TajdidDate)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TajdidHagVekalat).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TajdidHazinehDadresi).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<TbPrDasteh>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("TbPrDasteh");

            entity.Property(e => e.Code).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<TbRegion>(entity =>
        {
            entity.ToTable("TbRegion");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.Dscp)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Last).HasMaxLength(100);
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.HasEditAccess)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.HasRegionAccess)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<TbShahrestan>(entity =>
        {
            entity.ToTable("TbShahrestan");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsOstan).HasDefaultValueSql("((0))");
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<TbTarafeyn>(entity =>
        {
            entity.ToTable("TbTarafeyn");

            entity.Property(e => e.DeSetCode)
                .HasComment("شناسه مجموعه سازماني كاربر ثبت كننده ركورد")
                .HasColumnName("DE_SetCode");
            entity.Property(e => e.DeUserId)
                .HasComment("شناسه كاربر ثبت كننده ركورد")
                .HasColumnName("DE_UserId");
            entity.Property(e => e.Khahan).HasColumnName("khahan");
            entity.Property(e => e.Mdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("MDate");
            entity.Property(e => e.ReplAct)
                .HasDefaultValueSql("((2))")
                .HasComment("نوع رويداد")
                .HasColumnName("Repl_Act");
            entity.Property(e => e.ReplTime)
                .HasDefaultValueSql("(getdate())")
                .HasComment("زمان رويداد")
                .HasColumnType("datetime")
                .HasColumnName("Repl_Time");
            entity.Property(e => e.ReplUid)
                .HasDefaultValueSql("(newid())")
                .HasComment("مشخصه منحصر بفرد ركورد")
                .HasColumnName("Repl_UID");
            entity.Property(e => e.UpIp)
                .HasMaxLength(50)
                .HasComment("آي يي آدرس شبكه اي كاربر ويرايش كننده ركورد")
                .HasColumnName("UP_IP");
            entity.Property(e => e.UpMac)
                .HasMaxLength(50)
                .HasComment("مك آدرس شبكه اي كاربر ويرايش كننده ركورد")
                .HasColumnName("UP_MAC");
            entity.Property(e => e.UpPc)
                .HasMaxLength(200)
                .HasComment("نام كامپيوتر كاربر ويرايش كننده ركورد")
                .HasColumnName("Up_PC");
            entity.Property(e => e.UpSetCode)
                .HasComment("شناسه مجموعه سازماني كاربر ثبت كننده ركورد")
                .HasColumnName("Up_SetCode");
            entity.Property(e => e.UpUserId)
                .HasComment("شناسه كاربر ويرايش كننده ركورد")
                .HasColumnName("Up_UserId");
            entity.Property(e => e.Vakhilkhahan).HasDefaultValueSql("((1))");
            entity.Property(e => e.WfDscp)
                .HasMaxLength(200)
                .HasComment("آخرين شرح گردش كار")
                .HasColumnName("WF_Dscp");
            entity.Property(e => e.WfLevel)
                .HasComment("مرحله گردش كار")
                .HasColumnName("WF_Level");
            entity.Property(e => e.WfPath)
                .HasMaxLength(1000)
                .HasComment("مسير گردش كار")
                .HasColumnName("WF_Path");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);
            entity.Property(e => e.Username).HasMaxLength(200);
        });

        modelBuilder.Entity<TbUserRole>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);

            entity.HasOne(d => d.Role).WithMany(p => p.TbUserRoles).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User).WithMany(p => p.TbUserRoles).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
