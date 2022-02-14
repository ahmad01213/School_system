using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    public partial class UpdateTimeTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "TimeTables");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TimeTables",
                newName: "TeatcherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeatcherId",
                table: "TimeTables",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "TimeTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
