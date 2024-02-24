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
    }
}
