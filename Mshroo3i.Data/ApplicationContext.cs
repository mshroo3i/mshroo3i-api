using Microsoft.EntityFrameworkCore;
using Mshroo3i.Domain;

namespace Mshroo3i.Data
{
    public class ApplicationContext : DbContext
    {
        public const string ConnectionString = "Host=localhost;Port=5432;Database=mshroo3i;Username=postgres;Password=docker;Pooling=true;Minimum Pool Size=0;Maximum Pool Size=100;Connection Idle Lifetime=300;Internal Command Timeout=15;";

        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products {  get; set; }
        public DbSet<ProductOption> ProductOptions { get; set; }
        public DbSet<Option> Options { get; set; }

        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString).UseSnakeCaseNamingConvention();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Store configrations
            modelBuilder.Entity<Store>().HasKey(p => p.Id);
            modelBuilder.Entity<Store>().HasIndex(p => p.Shortcode).IsUnique();
            modelBuilder.Entity<Store>().HasMany(p => p.Products).WithOne().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Store>().Property(p => p.Created).HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Store>().Property(p => p.LastModified).HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Store>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Store>().Property(p => p.Shortcode).IsRequired();
            modelBuilder.Entity<Store>().Property(p => p.Currency).IsRequired();
            modelBuilder.Entity<Store>().Property(p => p.HeroImg).IsRequired();

            // Product configrations
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Created).HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Product>().Property(p => p.LastModified).HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Product>().HasMany(p => p.ProductOptions).WithOne().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();

            // ProductOption configrations
            modelBuilder.Entity<ProductOption>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductOption>().Property(p => p.Created).HasDefaultValueSql("NOW()");
            modelBuilder.Entity<ProductOption>().Property(p => p.LastModified).HasDefaultValueSql("NOW()");
            modelBuilder.Entity<ProductOption>().HasMany(p => p.Options).WithOne().OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductOption>().Property(p => p.OptionName).IsRequired();
            modelBuilder.Entity<ProductOption>().Property(p => p.OptionType).HasConversion<string>();

            // Options configurations
            modelBuilder.Entity<Option>().HasKey(p => p.Id);
            modelBuilder.Entity<Option>().Property(p => p.Created).HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Option>().Property(p => p.LastModified).HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Option>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Option>().Property(p => p.PriceIncrement).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified))
            {
                entry.Property("LastModified").CurrentValue = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
