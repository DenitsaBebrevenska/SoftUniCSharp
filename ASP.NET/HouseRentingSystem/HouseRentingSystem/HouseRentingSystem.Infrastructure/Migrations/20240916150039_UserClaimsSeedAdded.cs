using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UserClaimsSeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Agent Agentov", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "user:fullname", "Guest Guestov", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 3, "user:fullname", "Great Admin", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6413cc4-4064-4bb0-9e25-5f228eb41afe", "AQAAAAEAACcQAAAAEOneeL9lcUWkSkyMjOGeCnSgTS93QdRcgWMTgJpl03NZkI3YL1BSgbW38fnz4tByAw==", "6d267df4-4155-4022-9925-999b03d30cd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3e21f9e-a117-49d7-a978-a76385fd1dce", "AQAAAAEAACcQAAAAEGy9jdI+P6U8FR3y4zlA6A3tS6juWWtePO5L6z37hOGPUQEDyTrEbryq35XStjHC8Q==", "22d64cd7-4dad-424c-824e-251f46e47ce0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b9d11b7-f222-4f56-9ee3-b44c577d621d", "AQAAAAEAACcQAAAAEC1zjlK9RHTxX42m3ZVUNX9Ks+JN6a8zkImqUDICRoNz/SyiJA3kFBGm6pI0UIKiqQ==", "5ecbf677-4d28-43ac-a238-1bbef9bd1d4d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98ba2430-e228-473c-961c-991047593c80", "AQAAAAEAACcQAAAAEPJZuvex0lWlCFtTO07LCGPUIrVd8B0VAy9xyPfa859XQpiRcz2uy2nRNBmeGrVkdw==", "bca1ca92-723c-438f-b06e-cf2252504511" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "971474e0-71b2-4d15-b518-6e359df772f3", "AQAAAAEAACcQAAAAEBfpuEdkNPtSe2IgP6/JkDOyNZWKKX7TK8QedozNyKAEu9XLpbv2td8jcFO873cxYw==", "af796605-a967-4f55-885b-584a002bbf97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "937a2aca-b980-4421-b776-f1594727acdd", "AQAAAAEAACcQAAAAEM1byPGBFu//4cNSEsPt0ud8QnrAYQYSDmeeEJ/rso0X6KCNYMkvQEMJyWtTZpZ7yw==", "9101bca4-c5d9-4dbb-b5e2-dd35edc50664" });
        }
    }
}
