namespace iOrder.Win.DbAccess.Contexts.iOrder
{
    using System.Data.Entity;

    public class iOrderContext : DbContext
    {
        public iOrderContext()
            : base("name=iOrderConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<iOrderContext>());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
