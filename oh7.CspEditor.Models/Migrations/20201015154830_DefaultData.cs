using Microsoft.EntityFrameworkCore.Migrations;

namespace bekk.CspEditor.Models.Migrations
{
    public partial class DefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e788692a-0f4e-4c17-9598-db691d64d89d", 0, "597ce84d-5dbb-4a43-9dd2-5bed793df77b", "oistein.hay@bekk.no", true, true, null, "OISTEIN.HAY@BEKK.NO", "OISTEIN.HAY@BEKK.NO", "AQAAAAEAACcQAAAAEALac4OcmfYKbJMlCvDBeI2VauGmQgWZemhce+OoHvv9fGGSEdylmZeBcUWZaMgswA==", "+4748127526", true, "3WL3F6SR76IWVM55YTA42YSNR6L5EVYL", false, "oistein.hay@bekk.no" });

            migrationBuilder.InsertData(
                table: "CspDirectiveItemTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Source" },
                    { 2, "Hash" }
                });

            migrationBuilder.InsertData(
                table: "CspEditorSettings",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[] { 1, "DefaultCssStyling", "~/lib/bootstrap/dist/css/bootstrap.min.css" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e788692a-0f4e-4c17-9598-db691d64d89d");

            migrationBuilder.DeleteData(
                table: "CspDirectiveItemTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CspDirectiveItemTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CspEditorSettings",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
