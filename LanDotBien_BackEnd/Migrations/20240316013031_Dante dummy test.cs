using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LanDotBien_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Dantedummytest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "id", "EndDay", "PackageName", "Package_Description", "StartDay", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 15, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4282), "Basic", "Basic package", new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4271), true },
                    { 2L, new DateTime(2024, 4, 15, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4289), "Premium", "Premium package", new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4289), true }
                });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "id", "Role" },
                values: new object[,]
                {
                    { 1L, "Admin" },
                    { 2L, "Manager" },
                    { 3L, "Staff" },
                    { 4L, "ProductOwner" },
                    { 5L, "Customer" },
                    { 6L, "Guest" },
                    { 7L, "User" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "Address", "Dob", "Email", "Gender", "IdentityCard", "Image", "Name", "Package_id", "Password", "Permission_id", "Phone", "RegisterDay", "Status", "Username" },
                values: new object[,]
                {
                    { 1L, "Admin Address", new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4314), "admin@example.com", "Male", "123456789", "null", "Admin", 1L, "admin", 1L, 123456789, "03/16/2024 08:30:29", true, "admin" },
                    { 2L, "Manager Address", new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4344), "manager@example.com", "Female", "987654321", "null", "Manager", 1L, "manager", 2L, 987654321, "03/16/2024 08:30:29", true, "manager" },
                    { 3L, "Staff Address", new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4348), "staff@example.com", "Male", "456789123", "null", "Staff", 1L, "staff", 3L, 456789123, "03/16/2024 08:30:29", true, "staff" },
                    { 4L, "Owner Address", new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4351), "owner@example.com", "Female", "789123456", "null", "ProductOwner", 1L, "owner", 4L, 789123456, "03/16/2024 08:30:29", true, "owner" },
                    { 5L, "Customer Address", new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4355), "customer@example.com", "Male", "321654987", "null", "Customer", 1L, "customer", 5L, 321654987, "03/16/2024 08:30:29", true, "customer" },
                    { 6L, "Guest Address", new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4358), "guest@example.com", "Female", "654987321", "null", "Guest", 1L, "guest", 6L, 654987321, "03/16/2024 08:30:29", true, "guest" },
                    { 7L, "User Address", new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4395), "user@example.com", "Male", "159263478", "null", "User", 1L, "user", 7L, 159263478, "03/16/2024 08:30:29", true, "user" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "Date", "Total_Price", "User_id" },
                values: new object[] { 1L, new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4485), 100.0, 1L });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "ISBN", "Image", "Product_Description", "Product_Name", "Product_Price", "Status", "Type", "User_id" },
                values: new object[] { 1L, "123456789", "", "Description for Product 1", "Product 1", 100.0, true, "Type 1", 1L });

            migrationBuilder.InsertData(
                table: "Auction",
                columns: new[] { "id", "AuctionDay", "Auction_Name", "Deposit_Money", "Product_id", "StartDay", "Status" },
                values: new object[] { 1L, new DateTime(2024, 3, 23, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4445), "Auction 1", 50.0, 1L, new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4444), true });

            migrationBuilder.InsertData(
                table: "Bill",
                columns: new[] { "id", "Order_id", "Payment_Method", "Total_Price" },
                values: new object[] { 1L, 1L, "Credit Card", 100.0 });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "id", "Product_id", "User_id", "isSelected" },
                values: new object[] { 1L, 1L, 1L, true });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "id", "Order_id", "Product_id" },
                values: new object[] { 1L, 1L, 1L });

            migrationBuilder.InsertData(
                table: "Bid",
                columns: new[] { "id", "Auction_id", "BID", "Bid_time", "User_id" },
                values: new object[] { 1L, 1L, 60.0, new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4528), 1L });

            migrationBuilder.InsertData(
                table: "RoomRegistrations",
                columns: new[] { "id", "Auction_id", "Register_time", "User_id" },
                values: new object[] { 1L, 1L, new DateTime(2024, 3, 16, 8, 30, 29, 418, DateTimeKind.Local).AddTicks(4468), 1L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bid",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Bill",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Package",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "RoomRegistrations",
                keyColumn: "id",
                keyValue: 1L);

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

            migrationBuilder.DeleteData(
                table: "Auction",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserPermission",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "UserPermission",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "UserPermission",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "UserPermission",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "UserPermission",
                keyColumn: "id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "UserPermission",
                keyColumn: "id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Package",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "UserPermission",
                keyColumn: "id",
                keyValue: 1L);
        }
    }
}
