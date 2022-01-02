using Microsoft.EntityFrameworkCore;
using Mshroo3i.Domain;

namespace Mshroo3i.Data;

public sealed class ApplicationContext : DbContext
{
    public const string ConnectionString = @"Server=tcp:mshroo3idbserver.database.windows.net;Authentication=Active Directory Device Code Flow;Database=mshroo3idb;";

    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products {  get; set; }
    public DbSet<ProductField> ProductFields { get; set; }
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
        modelBuilder.Entity<Product>().HasMany(p => p.ProductFields).WithOne().OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
        modelBuilder.Entity<Product>().Property(p => p.ImageSrc);
        modelBuilder.Entity<Product>().Property(p => p.DisplayPrice).HasDefaultValue(true);

        // ProductOption configrations
        modelBuilder.Entity<ProductField>().HasKey(p => p.Id);
        modelBuilder.Entity<ProductField>().Property(p => p.Created).HasDefaultValueSql("GETUTCDATE()");
        modelBuilder.Entity<ProductField>().Property(p => p.LastModified).HasDefaultValueSql("GETUTCDATE()");
        modelBuilder.Entity<ProductField>().HasMany(p => p.Options).WithOne().OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProductField>().Property(p => p.OptionName).IsRequired();
        modelBuilder.Entity<ProductField>().Property(p => p.OptionType).HasConversion<string>();

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