using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class IdentityUserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                comment: "User`s First Name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                comment: "User`s Last Name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "977df189-bf47-4d2e-91a1-5c58d94eb121", "Guest", "Guestov", "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAELQOXay4sZ8hSvOgDe230Iw6X6j+FB1AWMCObWRBLTdgmTubX3V6uq6d4d6BkZdQCA==", "1466a807-7c47-4920-bd6f-686f7a4c8568" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4108307-a7cd-4704-b1bd-ef38b35f5498", "Agent", "Agentov", "AGENT@MAIL.COM", "AGENT@MAIL.COM", "AQAAAAEAACcQAAAAEBeBO18FWLf+zIkvHSwyeOmzGGGJ/1dRR2iO4Q/U6XzhE59iCD+hwjSPT6CO7ZQTrw==", "6f152885-d30f-4ee4-a702-5785a3655c66" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a383dcbb-4de8-4f1d-a12e-d035dd3ad5b0", "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAENTyWokBBihe5KzTtkj6mzZSdpolb66pr0qL8YkdFov6AqEtCo/f0PhGpdue2EIMjA==", "5797d858-1686-4713-8ecf-9333013031eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cbe2dc2-0184-4098-a693-d46a11d9f42d", "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEBazEEdZjt42sltU6FBqmaIcNBUv6bArKXh+2csBz4SpTXCyk8aRXb+JOHrjfRZusg==", "997b3655-cc71-4958-885c-2adc27d5fee0" });
        }
    }
}
