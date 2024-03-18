using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LanDotBien_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Dante : Migration
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
                    packageName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    package_Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    startDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    endDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false)
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
                    role = table.Column<string>(type: "longtext", nullable: false)
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
                    permission_id = table.Column<long>(type: "bigint", nullable: false),
                    package_id = table.Column<long>(type: "bigint", nullable: false),
                    identityCard = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<byte[]>(type: "longblob", nullable: true),
                    phone = table.Column<int>(type: "int", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    registerDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Package_package_id",
                        column: x => x.package_id,
                        principalTable: "Package",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserPermission_permission_id",
                        column: x => x.permission_id,
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
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    orderItem_id = table.Column<long>(type: "bigint", nullable: false),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    total_Price = table.Column<double>(type: "double", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_User_user_id",
                        column: x => x.user_id,
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
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    product_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_Price = table.Column<double>(type: "double", nullable: false),
                    type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_User_user_id",
                        column: x => x.user_id,
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
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    payment_Method = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    total_Price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bill_Order_order_id",
                        column: x => x.order_id,
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
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    startDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    endDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    auctionDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    auction_Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deposit_Money = table.Column<double>(type: "double", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.id);
                    table.ForeignKey(
                        name: "FK_Auction_Product_product_id",
                        column: x => x.product_id,
                        principalTable: "Product",
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
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_order_id",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_product_id",
                        column: x => x.product_id,
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
                    auction_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    bid = table.Column<double>(type: "double", nullable: false),
                    bid_time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bid_Auction_auction_id",
                        column: x => x.auction_id,
                        principalTable: "Auction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bid_User_user_id",
                        column: x => x.user_id,
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
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    auction_id = table.Column<long>(type: "bigint", nullable: false),
                    register_time = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomRegistrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_RoomRegistrations_Auction_auction_id",
                        column: x => x.auction_id,
                        principalTable: "Auction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomRegistrations_User_user_id",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Package",
                columns: new[] { "id", "endDay", "packageName", "package_Description", "startDay", "status" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 4, 17, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9206), "Basic", "Basic package", new DateTime(2024, 3, 18, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9193), true },
                    { 2L, new DateTime(2024, 4, 17, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9213), "Premium", "Premium package", new DateTime(2024, 3, 18, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9213), true }
                });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "id", "role" },
                values: new object[,]
                {
                    { 1L, "Admin" },
                    { 2L, "Manager" },
                    { 3L, "Staff" },
                    { 4L, "ProductOwner" },
                    { 5L, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "address", "dob", "email", "gender", "identityCard", "image", "name", "package_id", "password", "permission_id", "phone", "registerDay", "status", "username" },
                values: new object[] { 1L, "Admin Address", new DateTime(2024, 3, 18, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9240), "admin@example.com", "Male", "123456789", null, "Admin", 1L, "admin", 1L, 123456789, new DateTime(2024, 3, 18, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9242), true, "admin" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "id", "date", "orderItem_id", "status", "total_Price", "user_id" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 3, 18, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9333), 0L, 1, 100.0, 1L },
                    { 2L, new DateTime(2024, 3, 18, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9336), 0L, 2, 100.0, 1L },
                    { 3L, new DateTime(2024, 3, 18, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9337), 0L, 3, 100.0, 1L },
                    { 4L, new DateTime(2024, 3, 18, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9338), 0L, 4, 100.0, 1L }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "ISBN", "image", "product_Description", "product_Name", "product_Price", "status", "type", "user_id" },
                values: new object[] { 1L, "123456789", "", "Description for Product 1", "Product 1", 100.0, true, "Type 1", 1L });

            migrationBuilder.InsertData(
                table: "Auction",
                columns: new[] { "id", "auctionDay", "auction_Name", "deposit_Money", "endDay", "password", "product_id", "startDay", "status" },
                values: new object[] { 1L, new DateTime(2024, 3, 25, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9296), "Auction 1", 50.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", 1L, new DateTime(2024, 3, 18, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9294), 0 });

            migrationBuilder.InsertData(
                table: "Bill",
                columns: new[] { "id", "order_id", "payment_Method", "total_Price" },
                values: new object[] { 1L, 1L, "Credit Card", 100.0 });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "id", "order_id", "product_id" },
                values: new object[] { 1L, 1L, 1L });

            migrationBuilder.InsertData(
                table: "Bid",
                columns: new[] { "id", "auction_id", "bid", "bid_time", "user_id" },
                values: new object[] { 1L, 1L, 60.0, new DateTime(2024, 3, 18, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9397), 1L });

            migrationBuilder.InsertData(
                table: "RoomRegistrations",
                columns: new[] { "id", "auction_id", "register_time", "user_id" },
                values: new object[] { 1L, 1L, new DateTime(2024, 3, 18, 17, 31, 57, 921, DateTimeKind.Local).AddTicks(9316), 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Auction_product_id",
                table: "Auction",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_auction_id",
                table: "Bid",
                column: "auction_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_user_id",
                table: "Bid",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_order_id",
                table: "Bill",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_user_id",
                table: "Order",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_order_id",
                table: "OrderItem",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_product_id",
                table: "OrderItem",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_user_id",
                table: "Product",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRegistrations_auction_id",
                table: "RoomRegistrations",
                column: "auction_id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomRegistrations_user_id",
                table: "RoomRegistrations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_package_id",
                table: "User",
                column: "package_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_permission_id",
                table: "User",
                column: "permission_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "Bill");

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
