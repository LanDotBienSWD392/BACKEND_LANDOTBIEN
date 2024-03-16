using Microsoft.EntityFrameworkCore;

namespace LanVar.Core.Entity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RoomRegistrations> RoomRegistrations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPermission> UsersPermission { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for UserPermissions
            modelBuilder.Entity<UserPermission>().HasData(
                new UserPermission { id = 1, Role = "Admin" },
                new UserPermission { id = 2, Role = "Manager" },
                new UserPermission { id = 3, Role = "Staff" },
                new UserPermission { id = 4, Role = "ProductOwner" },
                new UserPermission { id = 5, Role = "Customer" },
                new UserPermission { id = 6, Role = "Guest" },
                new UserPermission { id = 7, Role = "User" }
            );

            // Seed data for Packages
            modelBuilder.Entity<Package>().HasData(
                new Package { id = 1, PackageName = "Basic", Package_Description = "Basic package", StartDay = DateTime.Now, EndDay = DateTime.Now.AddDays(30), Status = true },
                new Package { id = 2, PackageName = "Premium", Package_Description = "Premium package", StartDay = DateTime.Now, EndDay = DateTime.Now.AddDays(30), Status = true }
            );

            // Seed data for Users
            // Thằng nào muốn thêm thì tạo nhưng nó chưa giải quyết được chuyện mã hóa account
            //modelBuilder.Entity<User>().HasData(

            //);

            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product { id = 1, ISBN = "123456789", User_id = 1, Product_Name = "Product 1", Product_Description = "Description for Product 1", Image = "", Product_Price = 100.00, Type = "Type 1", Status = true }
            );

            // Seed data for Auctions
            modelBuilder.Entity<Auction>().HasData(
                new Auction { id = 1, Product_id = 1, StartDay = DateTime.Now, AuctionDay = DateTime.Now.AddDays(7), Auction_Name = "Auction 1", Deposit_Money = 50.00, Status = true }
            );

            // Seed data for RoomRegistrations
            modelBuilder.Entity<RoomRegistrations>().HasData(
                new RoomRegistrations { id = 1, User_id = 1, Auction_id = 1, Register_time = DateTime.Now }
            );

            // Seed data for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { id = 1, User_id = 1, Date = DateTime.Now, Total_Price = 100.00 }
            );

            // Seed data for OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { id = 1, Order_id = 1, Product_id = 1 }
            );

            // Seed data for Bills
            modelBuilder.Entity<Bill>().HasData(
                new Bill { id = 1, Order_id = 1, Payment_Method = "Credit Card", Total_Price = 100.00 }
            );

            // Seed data for Bids
            modelBuilder.Entity<Bid>().HasData(
                new Bid { id = 1, Auction_id = 1, User_id = 1, BID = 60.00, Bid_time = DateTime.Now }
            );

            // Seed data for Carts
            modelBuilder.Entity<Cart>().HasData(
                new Cart { id = 1, User_id = 1, Product_id = 1, isSelected = true }
            );
        }
    }
}
