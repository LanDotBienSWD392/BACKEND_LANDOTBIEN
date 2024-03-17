using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LanDotBien_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Dante_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Auction",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "AuctionDay", "StartDay" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7221), new DateTime(2024, 3, 17, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "Bid",
                keyColumn: "id",
                keyValue: 1L,
                column: "Bid_time",
                value: new DateTime(2024, 3, 17, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7315));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "Date", "Status" },
                values: new object[] { new DateTime(2024, 3, 17, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7263), "Confirmed" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "Date", "Status", "Total_Price", "User_id" },
                values: new object[,]
                {
                    { 2L, new DateTime(2024, 3, 17, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7265), "In Transit", 100.0, 1L },
                    { 3L, new DateTime(2024, 3, 17, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7266), "Delivered", 100.0, 1L },
                    { 4L, new DateTime(2024, 3, 17, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7267), "Canceled", 100.0, 1L }
                });

            migrationBuilder.UpdateData(
                table: "Package",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "EndDay", "StartDay" },
                values: new object[] { new DateTime(2024, 4, 16, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7115), new DateTime(2024, 3, 17, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7104) });

            migrationBuilder.UpdateData(
                table: "Package",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "EndDay", "StartDay" },
                values: new object[] { new DateTime(2024, 4, 16, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7121), new DateTime(2024, 3, 17, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7121) });

            migrationBuilder.UpdateData(
                table: "RoomRegistrations",
                keyColumn: "id",
                keyValue: 1L,
                column: "Register_time",
                value: new DateTime(2024, 3, 17, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "Dob", "RegisterDay" },
                values: new object[] { new DateTime(2024, 3, 17, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7175), new DateTime(2024, 3, 17, 15, 34, 46, 209, DateTimeKind.Local).AddTicks(7176) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "id",
                keyValue: 4L);

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
    }
}
