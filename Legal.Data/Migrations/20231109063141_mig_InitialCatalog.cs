using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Legal.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_InitialCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DoingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DoingDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbAshkhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NamePedar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Pisheh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Faks = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Site = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Jens = table.Column<byte>(type: "tinyint", nullable: true),
                    NoehAshkhasCode = table.Column<byte>(type: "tinyint", nullable: true),
                    DateTavalod = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Semat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DE_UserId = table.Column<int>(type: "int", nullable: true, comment: "شناسه كاربر ثبت كننده ركورد"),
                    DE_SetCode = table.Column<int>(type: "int", nullable: true, comment: "شناسه مجموعه سازماني كاربر ثبت كننده ركورد"),
                    WF_Level = table.Column<int>(type: "int", nullable: true, comment: "مرحله گردش كار"),
                    WF_Dscp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "آخرين شرح گردش كار"),
                    WF_Path = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "مسير گردش كار"),
                    Repl_Act = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((2))", comment: "نوع رويداد"),
                    Repl_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "زمان رويداد"),
                    Repl_UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "مشخصه منحصر بفرد ركورد"),
                    Up_UserId = table.Column<int>(type: "int", nullable: true, comment: "شناسه كاربر ويرايش كننده ركورد"),
                    Up_SetCode = table.Column<int>(type: "int", nullable: true, comment: "شناسه مجموعه سازماني كاربر ثبت كننده ركورد"),
                    Up_PC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "نام كامپيوتر كاربر ويرايش كننده ركورد"),
                    UP_IP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "آي يي آدرس شبكه اي كاربر ويرايش كننده ركورد"),
                    UP_MAC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "مك آدرس شبكه اي كاربر ويرايش كننده ركورد"),
                    CodeMeli = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CodePosti = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbAshkhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbKhahanTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbKhahanTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbNoyehParvandeh",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    khahanBadvi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KandehBadvi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    khahanTajdid = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    khandehTajdid = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbNoyehParvandeh", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TbParvandeh",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParvandehId = table.Column<int>(type: "int", nullable: true),
                    DateIjad = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    ShahrestanId = table.Column<int>(type: "int", nullable: true),
                    NoyehParvandehCode = table.Column<byte>(type: "tinyint", nullable: true),
                    ShParvandeh24 = table.Column<string>(type: "varchar(24)", unicode: false, maxLength: 24, nullable: true),
                    ShParvandeh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MarjaName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ShShobeh = table.Column<int>(type: "int", nullable: true),
                    khahan = table.Column<int>(type: "int", nullable: true),
                    Jaryan = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    Maly = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
                    Lah = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Khasteh = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Search1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Search2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateRay = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    HagVekalat = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    HazinehDadresi = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TajdidIs = table.Column<bool>(type: "bit", nullable: true),
                    TajdidDate = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    TajdidKhahan = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    RayTajdidOk = table.Column<bool>(type: "bit", nullable: true),
                    RayTajdidDate = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    TajdidHagVekalat = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TajdidHazinehDadresi = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    EjraIs = table.Column<bool>(type: "bit", nullable: true),
                    EjraDate = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    MakhtoomeDalil = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MakhtoomeDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MakhtoomeIs = table.Column<bool>(type: "bit", nullable: true),
                    RakedDalil = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    RakedDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RakedIs = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbParvandeh", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbParvandehBk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParvandehId = table.Column<int>(type: "int", nullable: true),
                    DateIjad = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    ShahrestanId = table.Column<int>(type: "int", nullable: true),
                    NoyehParvandehCode = table.Column<byte>(type: "tinyint", nullable: true),
                    ShParvandeh24 = table.Column<string>(type: "varchar(24)", unicode: false, maxLength: 24, nullable: true),
                    ShParvandeh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MarjaName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ShShobeh = table.Column<int>(type: "int", nullable: true),
                    khahan = table.Column<int>(type: "int", nullable: true),
                    Jaryan = table.Column<int>(type: "int", nullable: true),
                    Maly = table.Column<int>(type: "int", nullable: true),
                    Lah = table.Column<bool>(type: "bit", nullable: true),
                    Khasteh = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Search1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Search2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateRay = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    HagVekalat = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    HazinehDadresi = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TajdidIs = table.Column<bool>(type: "bit", nullable: true),
                    TajdidDate = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    TajdidKhahan = table.Column<bool>(type: "bit", nullable: false),
                    RayTajdidOk = table.Column<bool>(type: "bit", nullable: true),
                    RayTajdidDate = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    TajdidHagVekalat = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TajdidHazinehDadresi = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    EjraIs = table.Column<bool>(type: "bit", nullable: true),
                    EjraDate = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    MakhtoomeDalil = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MakhtoomeDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MakhtoomeIs = table.Column<bool>(type: "bit", nullable: true),
                    RakedDalil = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    RakedDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RakedIs = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbParvandehBk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbPrDasteh",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPrDasteh", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TbRegion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Dscp = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: true),
                    PrNum = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Last = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    Gid = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbRegion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HasDeveloperAccess = table.Column<bool>(type: "bit", nullable: false),
                    IsHeadquarters = table.Column<bool>(type: "bit", nullable: false),
                    HasOstanAccess = table.Column<bool>(type: "bit", nullable: false),
                    HasEditAccess = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    HasRegionAccess = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsOrganization = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    Gid = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbShahrestan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OstanId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    Gid = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    IsOstan = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbShahrestan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbTarafeyn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParvandehId = table.Column<int>(type: "int", nullable: true),
                    AshkhasId = table.Column<int>(type: "int", nullable: true),
                    MDate = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "(getdate())"),
                    DE_UserId = table.Column<int>(type: "int", nullable: true, comment: "شناسه كاربر ثبت كننده ركورد"),
                    DE_SetCode = table.Column<int>(type: "int", nullable: true, comment: "شناسه مجموعه سازماني كاربر ثبت كننده ركورد"),
                    WF_Level = table.Column<int>(type: "int", nullable: true, comment: "مرحله گردش كار"),
                    WF_Dscp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "آخرين شرح گردش كار"),
                    WF_Path = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "مسير گردش كار"),
                    Repl_Act = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((2))", comment: "نوع رويداد"),
                    Repl_Time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "زمان رويداد"),
                    Repl_UID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "مشخصه منحصر بفرد ركورد"),
                    Up_UserId = table.Column<int>(type: "int", nullable: true, comment: "شناسه كاربر ويرايش كننده ركورد"),
                    Up_SetCode = table.Column<int>(type: "int", nullable: true, comment: "شناسه مجموعه سازماني كاربر ثبت كننده ركورد"),
                    Up_PC = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "نام كامپيوتر كاربر ويرايش كننده ركورد"),
                    UP_IP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "آي يي آدرس شبكه اي كاربر ويرايش كننده ركورد"),
                    UP_MAC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "مك آدرس شبكه اي كاربر ويرايش كننده ركورد"),
                    khahan = table.Column<byte>(type: "tinyint", nullable: true),
                    Vakhilkhahan = table.Column<byte>(type: "tinyint", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTarafeyn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    Gid = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())"),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    OstanId = table.Column<int>(type: "int", nullable: true),
                    ShahrestanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbNoyehParvandehMarja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Lev = table.Column<int>(type: "int", nullable: true),
                    NoyehParvandehCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbNoyehParvandehMarja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbNoyehParvandehMarja_TbNoyehParvandeh",
                        column: x => x.NoyehParvandehCode,
                        principalTable: "TbNoyehParvandeh",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateTable(
                name: "TbOstan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    Gid = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbOstan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbOstan_TbRegion",
                        column: x => x.RegionId,
                        principalTable: "TbRegion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbNoyehParvandehMog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShahrestanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbMarjaMog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbMarjaMog_TbShahrestan",
                        column: x => x.ShahrestanId,
                        principalTable: "TbShahrestan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TbUserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<long>(type: "bigint", nullable: true),
                    CreateIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedIp = table.Column<string>(type: "nvarchar(22)", maxLength: 22, nullable: true),
                    Gid = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbUserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbUserRoles_TbRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TbRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbUserRoles_TbUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbNoyehParvandehMarja_NoyehParvandehCode",
                table: "TbNoyehParvandehMarja",
                column: "NoyehParvandehCode");

            migrationBuilder.CreateIndex(
                name: "IX_TbNoyehParvandehMog_ShahrestanId",
                table: "TbNoyehParvandehMog",
                column: "ShahrestanId");

            migrationBuilder.CreateIndex(
                name: "IX_TbOstan_RegionId",
                table: "TbOstan",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_TbUserRoles_RoleId",
                table: "TbUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TbUserRoles_UserId",
                table: "TbUserRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationLog");

            migrationBuilder.DropTable(
                name: "TbAshkhas");

            migrationBuilder.DropTable(
                name: "TbKhahanTitle");

            migrationBuilder.DropTable(
                name: "TbNoyehParvandehMarja");

            migrationBuilder.DropTable(
                name: "TbNoyehParvandehMog");

            migrationBuilder.DropTable(
                name: "TbOstan");

            migrationBuilder.DropTable(
                name: "TbParvandeh");

            migrationBuilder.DropTable(
                name: "TbParvandehBk");

            migrationBuilder.DropTable(
                name: "TbPrDasteh");

            migrationBuilder.DropTable(
                name: "TbTarafeyn");

            migrationBuilder.DropTable(
                name: "TbUserRoles");

            migrationBuilder.DropTable(
                name: "TbNoyehParvandeh");

            migrationBuilder.DropTable(
                name: "TbShahrestan");

            migrationBuilder.DropTable(
                name: "TbRegion");

            migrationBuilder.DropTable(
                name: "TbRoles");

            migrationBuilder.DropTable(
                name: "TbUsers");
        }
    }
}
