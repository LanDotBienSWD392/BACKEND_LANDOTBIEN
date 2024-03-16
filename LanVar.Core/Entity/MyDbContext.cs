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
        public DbSet<RoomRegistrations> RoomRegistrations { get; set;}
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
            modelBuilder.Entity<User>().HasData(
                new User { id = 1, Permission_id = 1, Package_id = 1, IdentityCard = "123456789", Name = "Admin", Email = "admin@example.com", Username = "admin", Password = "admin", Image = "null", Phone = 123456789, Dob = DateTime.Now, Address = "Admin Address", Gender = "Male", RegisterDay = DateTime.Now.ToString(), Status = true },
                new User { id = 2, Permission_id = 2, Package_id = 1, IdentityCard = "987654321", Name = "Manager", Email = "manager@example.com", Username = "manager", Password = "manager", Image = "null", Phone = 987654321, Dob = DateTime.Now, Address = "Manager Address", Gender = "Female", RegisterDay = DateTime.Now.ToString(), Status = true },
                new User { id = 3, Permission_id = 3, Package_id = 1, IdentityCard = "456789123", Name = "Staff", Email = "staff@example.com", Username = "staff", Password = "staff", Image = "null", Phone = 456789123, Dob = DateTime.Now, Address = "Staff Address", Gender = "Male", RegisterDay = DateTime.Now.ToString(), Status = true },
                new User { id = 4, Permission_id = 4, Package_id = 1, IdentityCard = "789123456", Name = "ProductOwner", Email = "owner@example.com", Username = "owner", Password = "owner", Image = "null", Phone = 789123456, Dob = DateTime.Now, Address = "Owner Address", Gender = "Female", RegisterDay = DateTime.Now.ToString(), Status = true },
                new User { id = 5, Permission_id = 5, Package_id = 1, IdentityCard = "321654987", Name = "Customer", Email = "customer@example.com", Username = "customer", Password = "customer", Image = "null", Phone = 321654987, Dob = DateTime.Now, Address = "Customer Address", Gender = "Male", RegisterDay = DateTime.Now.ToString(), Status = true },
                new User { id = 6, Permission_id = 6, Package_id = 1, IdentityCard = "654987321", Name = "Guest", Email = "guest@example.com", Username = "guest", Password = "guest", Image = "null", Phone = 654987321, Dob = DateTime.Now, Address = "Guest Address", Gender = "Female", RegisterDay = DateTime.Now.ToString(), Status = true },
                new User { id = 7, Permission_id = 7, Package_id = 1, IdentityCard = "159263478", Name = "User", Email = "user@example.com", Username = "user", Password = "user", Image = "null", Phone = 159263478, Dob = DateTime.Now, Address = "User Address", Gender = "Male", RegisterDay = DateTime.Now.ToString(), Status = true }
            );

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
