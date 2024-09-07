using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UniqueConstraintPhoneNumberAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a383dcbb-4de8-4f1d-a12e-d035dd3ad5b0", "AQAAAAEAACcQAAAAENTyWokBBihe5KzTtkj6mzZSdpolb66pr0qL8YkdFov6AqEtCo/f0PhGpdue2EIMjA==", "5797d858-1686-4713-8ecf-9333013031eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cbe2dc2-0184-4098-a693-d46a11d9f42d", "AQAAAAEAACcQAAAAEBazEEdZjt42sltU6FBqmaIcNBUv6bArKXh+2csBz4SpTXCyk8aRXb+JOHrjfRZusg==", "997b3655-cc71-4958-885c-2adc27d5fee0" });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_PhoneNumber",
                table: "Agents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53ca83a2-7e77-435a-a87a-8b77e0703177", "AQAAAAEAACcQAAAAEPcOrNOQHZCO6VQkWwJvc0HezaIrvTCpbRxAansCBQbzX1LmotBv85xqoC7ZQfozOw==", "53f1db4c-103d-4bbb-9a21-20a7004652e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "036ef3f6-c9ee-48df-98a6-f8a5bc4abf93", "AQAAAAEAACcQAAAAEG4AGjoE4GoHB/xUnclQsXocP94ZvOxafqtyaAGvty2vY2uIYJgau6Ka5u5/vXSK7g==", "517a3a94-5aca-45e2-9ca6-dc6abe7d7dfb" });
        }
    }
}
