using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class IsApprovedAddedToHouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Houses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the house approved by admin");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Houses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7640562-d142-4a2e-83ba-8f6b7cd7fab8", "AQAAAAEAACcQAAAAEJ3ffZVVcku6Mz6QELQQJiSFh5iDRST15lBE0lZPjsxQgCsLpg35WjLYWM4Ef3PG6Q==", "d0218080-cd85-474c-a07a-0c7dfffd67c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edc46910-108f-4e2e-99a3-1608f0a4ecba", "AQAAAAEAACcQAAAAEFJpUscjKRDTEFzmZAj9k1rGb+h+PeVMHzpXjF1qx9DZsyfjb/wpOwkzudvJo78i/Q==", "b50e6b03-e3a0-48f8-8da5-949fc7cfb390" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2469d62-a847-4d7e-bab2-21e41cda73a1", "AQAAAAEAACcQAAAAENJb/YceQA11fQQRv5H8nfqvXsF7wnKV7uLR3ZpFPDKSw63tR17PcTdAG0RsfYZZwA==", "44f3a459-4b74-41ba-baf7-a8df866fd064" });
        }
    }
}
