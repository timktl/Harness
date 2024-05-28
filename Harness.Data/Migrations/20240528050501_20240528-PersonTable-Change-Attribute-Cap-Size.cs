using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harness.Data.Migrations
{
    public partial class _20240528PersonTableChangeAttributeCapSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Person",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Person",
                newName: "Age");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Person",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Person",
                newName: "age");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Person",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
