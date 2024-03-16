using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LanDotBien_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Dante_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PackageName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Package_Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Permission_id = table.Column<long>(type: "bigint", nullable: false),
                    Package_id = table.Column<long>(type: "bigint", nullable: false),
                    IdentityCard = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegisterDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Package_Package_id",
                        column: x => x.Package_id,
                        principalTable: "Package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserPermission_Permission_id",
                        column: x => x.Permission_id,
                        principalTable: "UserPermission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_id = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Total_Price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_User_User_id",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ISBN = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    User_id = table.Column<long>(type: "bigint", nullable: false),
                    Product_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Product_Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Product_Price = table.Column<double>(type: "double", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_User_User_id",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Order_id = table.Column<long>(type: "bigint", nullable: false),
                    Payment_Method = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Total_Price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bill_Order_Order_id",
                        column: x => x.Order_id,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Auction",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Product_id = table.Column<long>(type: "bigint", nullable: false),
                    StartDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuctionDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Auction_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Deposit_Money = table.Column<double>(type: "double", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.id);
                    table.ForeignKey(
                        name: "FK_Auction_Product_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_id = table.Column<long>(type: "bigint", nullable: false),
                    Product_id = table.Column<long>(type: "bigint", nullable: false),
                    isSelected = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cart_Product_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_User_User_id",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Order_id = table.Column<long>(type: "bigint", nullable: false),
                    Product_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_Order_id",
                        column: x => x.Order_id,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_Product_id",
                        column: x => x.Product_id,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Auction_id = table.Column<long>(type: "bigint", nullable: false),
                    User_id = table.Column<long>(type: "bigint", nullable: false),
                    BID = table.Column<double>(type: "double", nullable: false),
                    Bid_time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bid_Auction_Auction_id",
                        column: x => x.Auction_id,
                        principalTable: "Auction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bid_User_User_id",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoomRegistrations",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_id = table.Column<long>(type: "bigint", nullable: false),
                    Auction_id = table.Column<long>(type: "bigint", nullable: false),
                    Register_time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomRegistrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_RoomRegistrations_Auction_Auction_id",
                        column: x => x.Auction_id,
                        principalTable: "Auction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomRegistrations_User_User_id",
                        column: x => x.User_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "id", "EndDay", "PackageName", "Package_Description", "StartDay", "Status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 15, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2478), "Basic", "Basic package", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2468), true },
                    { 2L, new DateTime(2024, 4, 15, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2485), "Premium", "Premium package", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2485), true }
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
                    { 1L, "Admin Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2510), "admin@example.com", "Male", "123456789", "null", "Admin", 1L, "admin", 1L, 123456789, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2512), true, "admin" },
                    { 2L, "Manager Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2515), "manager@example.com", "Female", "987654321", "null", "Manager", 1L, "manager", 2L, 987654321, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2516), true, "manager" },
                    { 3L, "Staff Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2518), "staff@example.com", "Male", "456789123", "null", "Staff", 1L, "staff", 3L, 456789123, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2518), true, "staff" },
                    { 4L, "Owner Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2520), "owner@example.com", "Female", "789123456", "null", "ProductOwner", 1L, "owner", 4L, 789123456, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2521), true, "owner" },
                    { 5L, "Customer Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2523), "customer@example.com", "Male", "321654987", "null", "Customer", 1L, "customer", 5L, 321654987, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2524), true, "customer" },
                    { 6L, "Guest Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2526), "guest@example.com", "Female", "654987321", "null", "Guest", 1L, "guest", 6L, 654987321, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2527), true, "guest" },
                    { 7L, "User Address", new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2528), "user@example.com", "Male", "159263478", "null", "User", 1L, "user", 7L, 159263478, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2529), true, "user" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "Date", "Total_Price", "User_id" },
                values: new object[] { 1L, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2624), 100.0, 1L });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "ISBN", "Image", "Product_Description", "Product_Name", "Product_Price", "Status", "Type", "User_id" },
                values: new object[] { 1L, "123456789", "", "Description for Product 1", "Product 1", 100.0, true, "Type 1", 1L });

            migrationBuilder.InsertData(
                table: "Auction",
                columns: new[] { "id", "AuctionDay", "Auction_Name", "Deposit_Money", "Product_id", "StartDay", "Status" },
                values: new object[] { 1L, new DateTime(2024, 3, 23, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2576), "Auction 1", 50.0, 1L, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2575), true });

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
                values: new object[] { 1L, 1L, 60.0, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2672), 1L });

            migrationBuilder.InsertData(
                table: "RoomRegistrations",
                columns: new[] { "id", "Auction_id", "Register_time", "User_id" },
                values: new object[] { 1L, 1L, new DateTime(2024, 3, 16, 11, 19, 54, 602, DateTimeKind.Local).AddTicks(2598), 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Auction_Product_id",
                table: "Auction",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_Auction_id",
                table: "Bid",
                column: "Auction_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_User_id",
                table: "Bid",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_Order_id",
                table: "Bill",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Product_id",
                table: "Cart",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_User_id",
                table: "Cart",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_User_id",
                table: "Order",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_Order_id",
                table: "OrderItem",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_Product_id",
                table: "OrderItem",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_User_id",
                table: "Product",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRegistrations_Auction_id",
                table: "RoomRegistrations",
                column: "Auction_id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRegistrations_User_id",
                table: "RoomRegistrations",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Package_id",
                table: "User",
                column: "Package_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Permission_id",
                table: "User",
                column: "Permission_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "RoomRegistrations");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Auction");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "UserPermission");
        }
    }
}
