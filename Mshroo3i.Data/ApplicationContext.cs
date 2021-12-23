using Microsoft.EntityFrameworkCore;
using Mshroo3i.Domain;

namespace Mshroo3i.Data;

public sealed class ApplicationContext : DbContext
{
    public const string ConnectionString = @"Server=tcp:mshroo3idbserver.database.windows.net;Authentication=Active Directory Device Code Flow;Database=mshroo3idb;";

    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products {  get; set; }
    public DbSet<ProductOption> ProductFields { get; set; }
    public DbSet<ProductFieldOption> ProductFieldOptions { get; set; }

    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Store configrations
        modelBuilder.Entity<Store>().HasKey(p => p.Id);
        modelBuilder.Entity<Store>().HasIndex(p => p.Shortcode).IsUnique();
        modelBuilder.Entity<Store>().HasMany(p => p.Products).WithOne(p => p.Store).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Store>().Property(p => p.Created).HasDefaultValueSql("GETUTCDATE()");
        modelBuilder.Entity<Store>().Property(p => p.LastModified).HasDefaultValueSql("GETUTCDATE()");
        modelBuilder.Entity<Store>().Property(p => p.NameAr).IsRequired();
        modelBuilder.Entity<Store>().Property(p => p.NameEn).IsRequired();
        modelBuilder.Entity<Store>().Property(p => p.Shortcode).IsRequired().HasMaxLength(40);
        modelBuilder.Entity<Store>().Property(p => p.Currency).IsRequired();
        modelBuilder.Entity<Store>().Property(p => p.HeroImg).IsRequired();
        modelBuilder.Entity<Store>().Property(p => p.InstagramHandle);
        modelBuilder.Entity<Store>().Property(p => p.WhatsAppUri).IsRequired();

        // Product configrations
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<Product>().Property(p => p.Created).HasDefaultValueSql("GETUTCDATE()");
        modelBuilder.Entity<Product>().Property(p => p.LastModified).HasDefaultValueSql("GETUTCDATE()");
        modelBuilder.Entity<Product>().HasMany(p => p.ProductOptions).WithOne().OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.ImageSrc);

        // ProductOption configrations
        modelBuilder.Entity<ProductOption>().HasKey(p => p.Id);
        modelBuilder.Entity<ProductOption>().Property(p => p.Created).HasDefaultValueSql("GETUTCDATE()");
        modelBuilder.Entity<ProductOption>().Property(p => p.LastModified).HasDefaultValueSql("GETUTCDATE()");
        modelBuilder.Entity<ProductOption>().HasMany(p => p.Options).WithOne().OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProductOption>().Property(p => p.OptionName).IsRequired();
        modelBuilder.Entity<ProductOption>().Property(p => p.OptionType).HasConversion<string>();

        // Options configurations
        modelBuilder.Entity<ProductFieldOption>().HasKey(p => p.Id);
        modelBuilder.Entity<ProductFieldOption>().Property(p => p.Created).HasDefaultValueSql("GETUTCDATE()");
        modelBuilder.Entity<ProductFieldOption>().Property(p => p.LastModified).HasDefaultValueSql("GETUTCDATE()");
        modelBuilder.Entity<ProductFieldOption>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<ProductFieldOption>().Property(p => p.PriceIncrement).IsRequired();

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