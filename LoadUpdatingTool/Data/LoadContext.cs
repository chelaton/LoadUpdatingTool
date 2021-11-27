using LoadUpdatingTool.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace LoadUpdatingTool.Data
{
    public class LoadContext : DbContext
    {
        public LoadContext(DbContextOptions<LoadContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Load;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }
        public DbSet<ServicePoint> ServicePoints { get; set; }
    }
}
