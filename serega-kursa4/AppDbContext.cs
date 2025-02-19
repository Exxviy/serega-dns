using serega_kursa4;
using System.Data.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext() : base("DefaultConnection")
    {
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppDbContext>());
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Shipment> Shipments { get; set; }

       //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    // Определение отношений между таблицами
    //    modelBuilder.Entity<Product>()
    //        .HasOne(p => p.CategoryInfo)
    //        .WithMany(c => c.Products)
    //        .HasForeignKey(p => p.CategoryID);

    //    modelBuilder.Entity<Order>()
    //        .HasMany(o => o.OrderItems)
    //        .WithOne(oi => oi.Order)
    //        .HasForeignKey(oi => oi.OrderID);

    //    modelBuilder.Entity<OrderItem>()
    //        .HasOne(oi => oi.Product)
    //        .WithMany()
    //        .HasForeignKey(oi => oi.ProductID);
    //}
}
