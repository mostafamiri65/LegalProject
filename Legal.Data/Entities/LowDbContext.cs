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

    public virtual DbSet<TbNoyehParvandeh> TbNoyehParvandehs { get; set; }

    public virtual DbSet<TbOstan> TbOstans { get; set; }

    public virtual DbSet<TbParvandeh> TbParvandehs { get; set; }

    public virtual DbSet<TbRegion> TbRegions { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbShahrestan> TbShahrestans { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbUserRole> TbUserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.1.37;Database=LowDb;User Id = sa;Password = M13961221@;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_100_CI_AS");

        modelBuilder.Entity<ApplicationLog>(entity =>
        {
            entity.ToTable("ApplicationLog");

            entity.Property(e => e.DoingDescription).HasMaxLength(500);
            entity.Property(e => e.TableName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbNoyehParvandeh>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("TbNoyehParvandeh");

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

        modelBuilder.Entity<TbRegion>(entity =>
        {
            entity.ToTable("TbRegion");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.Dscp)
                .HasMaxLength(200)
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
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);
            entity.Property(e => e.Title).HasMaxLength(50);
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
