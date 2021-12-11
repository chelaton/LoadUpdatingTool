using LoadUpdatingTool.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace LoadUpdatingTool.Data
{
    public partial class LoadContext : DbContext
    {
        public LoadContext()
        {
        }

        public LoadContext(DbContextOptions<LoadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysLoadInformationEvw> SysLoadInformationEvws { get; set; } = null!;
        public virtual DbSet<TeeLoadInformationEvw> TeeLoadInformationEvws { get; set; } = null!;
        public virtual DbSet<TeeServicePointEvw> TeeServicePointEvws { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Load;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SysLoadInformationEvw>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("SYS_LOAD_INFORMATION_evw");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CurveNumber).HasColumnName("CURVE_NUMBER");

                entity.Property(e => e.EnergyMwh)
                    .HasColumnType("numeric(38, 10)")
                    .HasColumnName("ENERGY_MWH");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.InsertionTime).HasColumnName("INSERTION_TIME");

                entity.Property(e => e.NumberOfCustomers).HasColumnName("NUMBER_OF_CUSTOMERS");

                entity.Property(e => e.PeakPower)
                    .HasColumnType("numeric(38, 10)")
                    .HasColumnName("PEAK_POWER");

                entity.Property(e => e.ReactivePower)
                    .HasColumnType("numeric(38, 10)")
                    .HasColumnName("REACTIVE_POWER");

                entity.Property(e => e.RwoCode)
                    .HasColumnType("numeric(38, 8)")
                    .HasColumnName("rwo_code");

                entity.Property(e => e.RwoGid).HasColumnName("rwo_gid");
            });

            modelBuilder.Entity<TeeLoadInformationEvw>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("TEE_LOAD_INFORMATION_evw");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CurveNumber).HasColumnName("CURVE_NUMBER");

                entity.Property(e => e.EnergyMwh)
                    .HasColumnType("numeric(38, 8)")
                    .HasColumnName("ENERGY_MWH");

                entity.Property(e => e.Gid).HasColumnName("gid");

                entity.Property(e => e.InsertionTime).HasColumnName("INSERTION_TIME");

                entity.Property(e => e.NumberOfCustomers).HasColumnName("NUMBER_OF_CUSTOMERS");

                entity.Property(e => e.PeakPower)
                    .HasColumnType("numeric(38, 8)")
                    .HasColumnName("PEAK_POWER");

                entity.Property(e => e.PowerFactor)
                    .HasColumnType("numeric(38, 8)")
                    .HasColumnName("POWER_FACTOR");

                entity.Property(e => e.ReactivePower)
                    .HasColumnType("numeric(38, 8)")
                    .HasColumnName("REACTIVE_POWER");

                entity.Property(e => e.RwoCode)
                    .HasColumnType("numeric(38, 8)")
                    .HasColumnName("rwo_code");

                entity.Property(e => e.RwoGid).HasColumnName("rwo_gid");
            });

            modelBuilder.Entity<TeeServicePointEvw>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("TEE_SERVICE_POINT_evw");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConversionInfo)
                    .HasMaxLength(600)
                    .HasColumnName("CONVERSION_INFO");

                entity.Property(e => e.Gid).HasColumnName("gid");

                //entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Identification)
                    .HasMaxLength(32)
                    .HasColumnName("IDENTIFICATION");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
