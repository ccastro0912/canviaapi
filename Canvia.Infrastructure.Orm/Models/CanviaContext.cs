using Microsoft.EntityFrameworkCore;


namespace Canvia.Infrastructure.Orm.Models
{
    public partial class CanviaContext : DbContext
    {
        public CanviaContext(DbContextOptions<CanviaContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Cp> Cps { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ItemCp> ItemCps { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.PKID)
                    .HasName("PK__CUSTOMER__18ASBMMDIK8C5F9S");

                entity.ToTable("Customer");

                entity.Property(e => e.PKID)
                    .UseIdentityColumn()
                    .HasColumnName("PKID");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .HasColumnName("Codigo");

                entity.Property(e => e.DocIdentidad)
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .HasColumnName("DocIdentidad");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Email");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Apellidos");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombres");

                entity.Property(e => e.Activo)
                    .IsUnicode(false)
                    .HasColumnName("Activo");
            });

            modelBuilder.Entity<Cp>(entity =>
            {
                entity.HasKey(e => e.PKID)
                    .HasName("PK__CP__21APPSKLPK976P8P");

                entity.ToTable("Cp");

                entity.Property(e => e.PKID)
                    .UseIdentityColumn()
                    .HasColumnName("PKID");

                entity.Property(e => e.NumCp)
                    .HasMaxLength(150)
                    .IsUnicode(true)
                    .HasColumnName("NumCp");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Moneda");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("FechaCreacion");

                entity.Property(e => e.Total)
                   .HasColumnType("decimal(18,2)")
                   .HasColumnName("Total");

                entity.Property(e => e.SubTotal)
                  .HasColumnType("decimal(18,2)")
                  .HasColumnName("SubTotal");


                entity.Property(e => e.IdCustomer).HasColumnName("IDCustomer");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Cps)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK__CUSTOMER_CP__88P7C438");
            });

            modelBuilder.Entity<ItemCp>(entity =>
            {
                entity.HasKey(e => e.PKID)
                    .HasName("PK__ITEMCP__21APPSKLPK976P8P");

                entity.ToTable("ItemCp");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Cantidad");

                entity.Property(e => e.Total)
                   .HasColumnType("decimal(18,2)")
                   .HasColumnName("Total");

                entity.Property(e => e.SubTotal)
                  .HasColumnType("decimal(18,2)")
                  .HasColumnName("SubTotal");

                entity.Property(e => e.IdProduct).HasColumnName("IDProducto");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ItemCps)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK__PRODUCT_ITEMCP__88P7C438");

                entity.Property(e => e.IdCp).HasColumnName("IDCp");

                entity.HasOne(d => d.IdCpNavigation)
                    .WithMany(p => p.ItemCps)
                    .HasForeignKey(d => d.IdCp)
                    .HasConstraintName("FK__CP_ITEMCP__88P7C438");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PKID)
                    .HasName("PK__PRODUCT__18ASBMMDIK8C5F9S");

                entity.ToTable("Product");

                entity.Property(e => e.PKID)
                    .UseIdentityColumn()
                    .HasColumnName("PKID");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .HasColumnName("Codigo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nombre");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Descripcion");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18,2)")
                    .HasColumnName("Precio");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("FechaCreacion");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("int")
                    .HasColumnName("Cantidad");

                entity.Property(e => e.Estado)
                    .IsUnicode(false)
                    .HasColumnName("Estado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
