using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_Management_System.Migrations
{
    public partial class UpdateAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "Minute",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "UserNo",
                table: "Attendances");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Attendances",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "SchoolId",
                table: "Attendances",
                newName: "CardNumber");

            migrationBuilder.AddColumn<string>(
                name: "InTime",
                table: "TimeTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OutTime",
                table: "TimeTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InTime",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "OutTime",
                table: "TimeTables");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Attendances",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "Attendances",
                newName: "SchoolId");

            migrationBuilder.AddColumn<int>(
                name: "Hour",
                table: "TimeTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minute",
                table: "TimeTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserNo",
                table: "Attendances",
                type: "int",
                nullable: true);
        }
    }
}
