﻿// <auto-generated />
using System;
using LanVar.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LanDotBien_BackEnd.Migrations
{
    [DbContext(typeof(MyDbContext))]
<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
    [Migration("20240317182848_Dante")]
    partial class Dante
========
    [Migration("20240317191444_Dluong")]
    partial class Dluong
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LanVar.Core.Entity.Auction", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("auctionDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("auction_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("deposit_Money")
                        .HasColumnType("double");

                    b.Property<DateTime>("endDay")
                        .HasColumnType("datetime(6)");

<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
                    b.Property<long>("product_id")
========
                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Product_id")
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
                        .HasColumnType("bigint");

                    b.Property<DateTime>("startDay")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("product_id");

                    b.ToTable("Auction");

                    b.HasData(
                        new
                        {
                            id = 1L,
<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
                            auctionDay = new DateTime(2024, 3, 25, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1599),
                            auction_Name = "Auction 1",
                            deposit_Money = 50.0,
                            endDay = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            product_id = 1L,
                            startDay = new DateTime(2024, 3, 18, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1598),
                            status = 0
========
                            AuctionDay = new DateTime(2024, 3, 25, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(9059),
                            Auction_Name = "Auction 1",
                            Deposit_Money = 50.0,
                            EndDay = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "123456",
                            Product_id = 1L,
                            StartDay = new DateTime(2024, 3, 18, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(9058),
                            Status = 0
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Bid", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("auction_id")
                        .HasColumnType("bigint");

                    b.Property<double>("bid")
                        .HasColumnType("double");

                    b.Property<DateTime>("bid_time")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("auction_id");

                    b.HasIndex("user_id");

                    b.ToTable("Bid");

                    b.HasData(
                        new
                        {
                            id = 1L,
<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
                            auction_id = 1L,
                            bid = 60.0,
                            bid_time = new DateTime(2024, 3, 18, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1724),
                            user_id = 1L
========
                            Auction_id = 1L,
                            BID = 60.0,
                            Bid_time = new DateTime(2024, 3, 18, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(9169),
                            User_id = 1L
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Bill", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("order_id")
                        .HasColumnType("bigint");

                    b.Property<string>("payment_Method")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("total_Price")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.HasIndex("order_id");

                    b.ToTable("Bill");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            order_id = 1L,
                            payment_Method = "Credit Card",
                            total_Price = 100.0
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Order", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("orderItem_id")
                        .HasColumnType("bigint");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<double>("total_Price")
                        .HasColumnType("double");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            id = 1L,
<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
                            date = new DateTime(2024, 3, 18, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1642),
                            orderItem_id = 0L,
                            status = 1,
                            total_Price = 100.0,
                            user_id = 1L
========
                            Date = new DateTime(2024, 3, 18, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(9107),
                            Status = 0,
                            Total_Price = 100.0,
                            User_id = 1L
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
                        },
                        new
                        {
                            id = 2L,
<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
                            date = new DateTime(2024, 3, 18, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1646),
                            orderItem_id = 0L,
                            status = 2,
                            total_Price = 100.0,
                            user_id = 1L
========
                            Date = new DateTime(2024, 3, 18, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(9109),
                            Status = 1,
                            Total_Price = 100.0,
                            User_id = 1L
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
                        },
                        new
                        {
                            id = 3L,
<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
                            date = new DateTime(2024, 3, 18, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1647),
                            orderItem_id = 0L,
                            status = 3,
                            total_Price = 100.0,
                            user_id = 1L
========
                            Date = new DateTime(2024, 3, 18, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(9110),
                            Status = 2,
                            Total_Price = 100.0,
                            User_id = 1L
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
                        },
                        new
                        {
                            id = 4L,
<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
                            date = new DateTime(2024, 3, 18, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1648),
                            orderItem_id = 0L,
                            status = 4,
                            total_Price = 100.0,
                            user_id = 1L
========
                            Date = new DateTime(2024, 3, 18, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(9111),
                            Status = 3,
                            Total_Price = 100.0,
                            User_id = 1L
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.OrderItem", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("order_id")
                        .HasColumnType("bigint");

                    b.Property<long>("product_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("order_id");

                    b.HasIndex("product_id");

                    b.ToTable("OrderItem");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            order_id = 1L,
                            product_id = 1L
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Package", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("endDay")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("packageName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("package_Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("startDay")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("id");

                    b.ToTable("Package");

                    b.HasData(
                        new
                        {
                            id = 1L,
<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
                            endDay = new DateTime(2024, 4, 17, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1502),
                            packageName = "Basic",
                            package_Description = "Basic package",
                            startDay = new DateTime(2024, 3, 18, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1486),
                            status = true
========
                            EndDay = new DateTime(2024, 4, 17, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(8971),
                            PackageName = "Basic",
                            Package_Description = "Basic package",
                            StartDay = new DateTime(2024, 3, 18, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(8961),
                            Status = true
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
                        },
                        new
                        {
                            id = 2L,
<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
                            endDay = new DateTime(2024, 4, 17, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1514),
                            packageName = "Premium",
                            package_Description = "Premium package",
                            startDay = new DateTime(2024, 3, 18, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1513),
                            status = true
========
                            EndDay = new DateTime(2024, 4, 17, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(8981),
                            PackageName = "Premium",
                            Package_Description = "Premium package",
                            StartDay = new DateTime(2024, 3, 18, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(8981),
                            Status = true
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Product", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("product_Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("product_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("product_Price")
                        .HasColumnType("double");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            ISBN = "123456789",
                            image = "",
                            product_Description = "Description for Product 1",
                            product_Name = "Product 1",
                            product_Price = 100.0,
                            status = true,
                            type = "Type 1",
                            user_id = 1L
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.RoomRegistrations", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("auction_id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("register_time")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("auction_id");

                    b.HasIndex("user_id");

                    b.ToTable("RoomRegistrations");

                    b.HasData(
                        new
                        {
                            id = 1L,
<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
                            auction_id = 1L,
                            register_time = new DateTime(2024, 3, 18, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1623),
                            user_id = 1L
========
                            Auction_id = 1L,
                            Register_time = new DateTime(2024, 3, 18, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(9086),
                            User_id = 1L
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("identityCard")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("package_id")
                        .HasColumnType("bigint");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("permission_id")
                        .HasColumnType("bigint");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<DateTime>("registerDay")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("status")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("package_id");

                    b.HasIndex("permission_id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            id = 1L,
<<<<<<<< HEAD:LanDotBien_BackEnd/Migrations/20240317182848_Dante.Designer.cs
                            address = "Admin Address",
                            dob = new DateTime(2024, 3, 18, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1547),
                            email = "admin@example.com",
                            gender = "Male",
                            identityCard = "123456789",
                            image = "null",
                            name = "Admin",
                            package_id = 1L,
                            password = "admin",
                            permission_id = 1L,
                            phone = 123456789,
                            registerDay = new DateTime(2024, 3, 18, 1, 28, 45, 895, DateTimeKind.Local).AddTicks(1548),
                            status = true,
                            username = "admin"
========
                            Address = "Admin Address",
                            Dob = new DateTime(2024, 3, 18, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(9010),
                            Email = "admin@example.com",
                            Gender = "Male",
                            IdentityCard = "123456789",
                            Image = "null",
                            Name = "Admin",
                            Package_id = 1L,
                            Password = "admin",
                            Permission_id = 1L,
                            Phone = 123456789,
                            RegisterDay = new DateTime(2024, 3, 18, 2, 14, 43, 415, DateTimeKind.Local).AddTicks(9012),
                            Status = true,
                            Username = "admin"
>>>>>>>> origin/Dluong:LanDotBien_BackEnd/Migrations/20240317191444_Dluong.Designer.cs
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.UserPermission", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("UserPermission");

                    b.HasData(
                        new
                        {
                            id = 1L,
                            role = "Admin"
                        },
                        new
                        {
                            id = 2L,
                            role = "Manager"
                        },
                        new
                        {
                            id = 3L,
                            role = "Staff"
                        },
                        new
                        {
                            id = 4L,
                            role = "ProductOwner"
                        },
                        new
                        {
                            id = 5L,
                            role = "Customer"
                        },
                        new
                        {
                            id = 6L,
                            role = "Guest"
                        },
                        new
                        {
                            id = 7L,
                            role = "User"
                        });
                });

            modelBuilder.Entity("LanVar.Core.Entity.Auction", b =>
                {
                    b.HasOne("LanVar.Core.Entity.Product", "product")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("LanVar.Core.Entity.Bid", b =>
                {
                    b.HasOne("LanVar.Core.Entity.Auction", "auction")
                        .WithMany()
                        .HasForeignKey("auction_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanVar.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("auction");

                    b.Navigation("user");
                });

            modelBuilder.Entity("LanVar.Core.Entity.Bill", b =>
                {
                    b.HasOne("LanVar.Core.Entity.Order", "order")
                        .WithMany()
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");
                });

            modelBuilder.Entity("LanVar.Core.Entity.Order", b =>
                {
                    b.HasOne("LanVar.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("LanVar.Core.Entity.OrderItem", b =>
                {
                    b.HasOne("LanVar.Core.Entity.Order", "order")
                        .WithMany()
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanVar.Core.Entity.Product", "product")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("LanVar.Core.Entity.Product", b =>
                {
                    b.HasOne("LanVar.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("LanVar.Core.Entity.RoomRegistrations", b =>
                {
                    b.HasOne("LanVar.Core.Entity.Auction", "auction")
                        .WithMany()
                        .HasForeignKey("auction_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanVar.Core.Entity.User", "user")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("auction");

                    b.Navigation("user");
                });

            modelBuilder.Entity("LanVar.Core.Entity.User", b =>
                {
                    b.HasOne("LanVar.Core.Entity.Package", "package")
                        .WithMany()
                        .HasForeignKey("package_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LanVar.Core.Entity.UserPermission", "userPermission")
                        .WithMany()
                        .HasForeignKey("permission_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("package");

                    b.Navigation("userPermission");
                });
#pragma warning restore 612, 618
        }
    }
}
