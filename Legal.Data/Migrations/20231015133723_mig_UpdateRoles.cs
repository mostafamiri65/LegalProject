using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Legal.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_UpdateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasEditAccess",
                table: "TbRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRegionAccess",
                table: "TbRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasEditAccess",
                table: "TbRoles");

            migrationBuilder.DropColumn(
                name: "HasRegionAccess",
                table: "TbRoles");
        }
    }
}
