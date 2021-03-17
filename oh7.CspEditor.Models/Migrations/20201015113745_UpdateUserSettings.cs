using Microsoft.EntityFrameworkCore.Migrations;

namespace bekk.CspEditor.Models.Migrations
{
    public partial class UpdateUserSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "SelectedCssStyling",
                table: "UserSettings");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "UserSettings",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserSettings",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "UserSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "UserSettings",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "UserSettings");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "UserSettings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedCssStyling",
                table: "UserSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings",
                column: "OwnerId");
        }
    }
}
