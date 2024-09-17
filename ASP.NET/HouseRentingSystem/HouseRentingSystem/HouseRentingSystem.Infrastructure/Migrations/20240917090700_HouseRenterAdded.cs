using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class HouseRenterAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Houses",
                type: "nvarchar(450)",
                nullable: true,
                comment: "The user`s identifier who rents the house",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "The user`s identifier who rents the house");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84cb9bd3-6476-4242-9b68-70b528619524", "AQAAAAEAACcQAAAAEENi+YOv9RzdKf5TLJ3qfj29Ar3UTs3kpyixBwTDgpgU7Nduo8xXH/HEy+Ub/DcIKg==", "2fe95a72-46fa-44f3-8522-2f9513f8bb8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6d6b20a-1289-46e3-ac1d-a3166bd8551e", "AQAAAAEAACcQAAAAEKZ/qFo5z2H6TaKbDDrFNBUIw1QZu+y/mwCwmMqikkpc1BcNFbiCY9LkJtZ4U3PCuQ==", "6d6fce72-5a63-4a6d-b7f3-79879e419ec8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21f1596a-1505-4931-9d0b-c21a4aaf8732", "AQAAAAEAACcQAAAAEBMwqo1+N7u5LCcG3soZ0MBj7SEJDoJAhtaNMXSXp4KBkQXi/tozCtpES6CA+zcgcw==", "e42a1a94-a48e-4582-8468-063e8bb4945f" });

            migrationBuilder.CreateIndex(
                name: "IX_Houses_RenterId",
                table: "Houses",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_AspNetUsers_RenterId",
                table: "Houses",
                column: "RenterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_AspNetUsers_RenterId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Houses_RenterId",
                table: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Agents_UserId",
                table: "Agents");

            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true,
                comment: "The user`s identifier who rents the house",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "The user`s identifier who rents the house");

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

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");
        }
    }
}
