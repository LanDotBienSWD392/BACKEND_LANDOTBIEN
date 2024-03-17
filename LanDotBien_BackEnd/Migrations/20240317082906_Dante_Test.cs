using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LanDotBien_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Dante_Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Order",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "AuctionDay", "StartDay" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 29, 3, 957, DateTimeKind.Local).AddTicks(4555), new DateTime(2024, 3, 17, 15, 29, 3, 957, DateTimeKind.Local).AddTicks(4554) });

            migrationBuilder.UpdateData(
                table: "Bid",
                keyColumn: "id",
                keyValue: 1L,
                column: "Bid_time",
                value: new DateTime(2024, 3, 17, 15, 29, 3, 957, DateTimeKind.Local).AddTicks(4675));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "Date", "Status" },
                values: new object[] { new DateTime(2024, 3, 17, 15, 29, 3, 957, DateTimeKind.Local).AddTicks(4596), "Con Hang" });

            migrationBuilder.UpdateData(
                table: "Package",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "EndDay", "StartDay" },
                values: new object[] { new DateTime(2024, 4, 16, 15, 29, 3, 957, DateTimeKind.Local).AddTicks(4476), new DateTime(2024, 3, 17, 15, 29, 3, 957, DateTimeKind.Local).AddTicks(4467) });

            migrationBuilder.UpdateData(
                table: "Package",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "EndDay", "StartDay" },
                values: new object[] { new DateTime(2024, 4, 16, 15, 29, 3, 957, DateTimeKind.Local).AddTicks(4488), new DateTime(2024, 3, 17, 15, 29, 3, 957, DateTimeKind.Local).AddTicks(4487) });

            migrationBuilder.UpdateData(
                table: "RoomRegistrations",
                keyColumn: "id",
                keyValue: 1L,
                column: "Register_time",
                value: new DateTime(2024, 3, 17, 15, 29, 3, 957, DateTimeKind.Local).AddTicks(4577));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "Dob", "RegisterDay" },
                values: new object[] { new DateTime(2024, 3, 17, 15, 29, 3, 957, DateTimeKind.Local).AddTicks(4512), new DateTime(2024, 3, 17, 15, 29, 3, 957, DateTimeKind.Local).AddTicks(4514) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Order");

            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "AuctionDay", "StartDay" },
                values: new object[] { new DateTime(2024, 3, 23, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2576), new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2575) });

            migrationBuilder.UpdateData(
                table: "Bid",
                keyColumn: "id",
                keyValue: 1L,
                column: "Bid_time",
                value: new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2672));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2624));

            migrationBuilder.UpdateData(
                table: "Package",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "EndDay", "StartDay" },
                values: new object[] { new DateTime(2024, 4, 15, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2478), new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2468) });

            migrationBuilder.UpdateData(
                table: "Package",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "EndDay", "StartDay" },
                values: new object[] { new DateTime(2024, 4, 15, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2485), new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "RoomRegistrations",
                keyColumn: "id",
                keyValue: 1L,
                column: "Register_time",
                value: new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "Dob", "RegisterDay" },
                values: new object[] { new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2510), new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2512) });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "Address", "Dob", "Email", "Gender", "IdentityCard", "Image", "Name", "Package_id", "Password", "Permission_id", "Phone", "RegisterDay", "Status", "Username" },
                values: new object[,]
                {
                    { 2L, "Manager Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2515), "manager@example.com", "Female", "987654321", "null", "Manager", 1L, "manager", 2L, 987654321, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2516), true, "manager" },
                    { 3L, "Staff Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2518), "staff@example.com", "Male", "456789123", "null", "Staff", 1L, "staff", 3L, 456789123, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2518), true, "staff" },
                    { 4L, "Owner Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2520), "owner@example.com", "Female", "789123456", "null", "ProductOwner", 1L, "owner", 4L, 789123456, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2521), true, "owner" },
                    { 5L, "Customer Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2523), "customer@example.com", "Male", "321654987", "null", "Customer", 1L, "customer", 5L, 321654987, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2524), true, "customer" },
                    { 6L, "Guest Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2526), "guest@example.com", "Female", "654987321", "null", "Guest", 1L, "guest", 6L, 654987321, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2527), true, "guest" },
                    { 7L, "User Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2528), "user@example.com", "Male", "159263478", "null", "User", 1L, "user", 7L, 159263478, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2529), true, "user" }
                });
        }
    }
}
