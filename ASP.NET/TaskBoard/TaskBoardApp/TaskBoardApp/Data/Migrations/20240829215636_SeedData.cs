using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f48b0b81-f5a8-431a-a3b6-7743d64e5820", 0, "6c5ca84d-97d8-40a1-9443-4a25ae2c1071", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEDncKDIUYprb8xM6/S7kFniOdA56Pfwv7Z1gSjYuGBI6diKSkHublPBZzPQzn2G8YQ==", null, false, "2c2d8873-a3d6-48fa-bb70-79d4b8ce809f", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 9, 0, 56, 36, 356, DateTimeKind.Local).AddTicks(9570), "Write hello world in javascript", "f48b0b81-f5a8-431a-a3b6-7743d64e5820", "Write hello world" },
                    { 2, 1, new DateTime(2024, 7, 31, 0, 56, 36, 356, DateTimeKind.Local).AddTicks(9607), "Search more info on MVC and watch some youtube tutorials", "f48b0b81-f5a8-431a-a3b6-7743d64e5820", "Read about MVC" },
                    { 3, 2, new DateTime(2024, 8, 20, 0, 56, 36, 356, DateTimeKind.Local).AddTicks(9610), "Make my AJAX exercises and solve some JS exams", "f48b0b81-f5a8-431a-a3b6-7743d64e5820", "Work with AJAX" },
                    { 4, 3, new DateTime(2024, 7, 1, 0, 56, 36, 356, DateTimeKind.Local).AddTicks(9612), "Watch Udemy Angular course and do the tasks", "f48b0b81-f5a8-431a-a3b6-7743d64e5820", "Play around with Angular" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f48b0b81-f5a8-431a-a3b6-7743d64e5820");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
