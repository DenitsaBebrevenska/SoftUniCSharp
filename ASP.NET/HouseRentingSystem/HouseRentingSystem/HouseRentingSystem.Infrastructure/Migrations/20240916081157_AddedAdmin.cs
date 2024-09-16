using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class AddedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7640562-d142-4a2e-83ba-8f6b7cd7fab8", "AQAAAAEAACcQAAAAEJ3ffZVVcku6Mz6QELQQJiSFh5iDRST15lBE0lZPjsxQgCsLpg35WjLYWM4Ef3PG6Q==", "d0218080-cd85-474c-a07a-0c7dfffd67c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2469d62-a847-4d7e-bab2-21e41cda73a1", "AQAAAAEAACcQAAAAENJb/YceQA11fQQRv5H8nfqvXsF7wnKV7uLR3ZpFPDKSw63tR17PcTdAG0RsfYZZwA==", "44f3a459-4b74-41ba-baf7-a8df866fd064" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "edc46910-108f-4e2e-99a3-1608f0a4ecba", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEFJpUscjKRDTEFzmZAj9k1rGb+h+PeVMHzpXjF1qx9DZsyfjb/wpOwkzudvJo78i/Q==", null, false, "b50e6b03-e3a0-48f8-8da5-949fc7cfb390", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 3, "+359888888800", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "977df189-bf47-4d2e-91a1-5c58d94eb121", "AQAAAAEAACcQAAAAELQOXay4sZ8hSvOgDe230Iw6X6j+FB1AWMCObWRBLTdgmTubX3V6uq6d4d6BkZdQCA==", "1466a807-7c47-4920-bd6f-686f7a4c8568" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4108307-a7cd-4704-b1bd-ef38b35f5498", "AQAAAAEAACcQAAAAEBeBO18FWLf+zIkvHSwyeOmzGGGJ/1dRR2iO4Q/U6XzhE59iCD+hwjSPT6CO7ZQTrw==", "6f152885-d30f-4ee4-a702-5785a3655c66" });
        }
    }
}
