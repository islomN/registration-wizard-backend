using Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Database;

public class EntityContext: BaseEntityContext
{
    protected string ConnectionString { get; set;}

    public EntityContext(IOptions<EntityContextOptions> options)
    {
        ConnectionString = options.Value.ConnectionString;
    }
    
    public EntityContext(string connectionString)
    {
        ConnectionString = connectionString;
    }
    
    public DbSet<Country> Countries { get; set; }
    
    public DbSet<Province> Provinces { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(i => i.Login).IsUnique();
        
        modelBuilder.Entity<Country>()
            .HasData(
                new List<Country>
                {
                    new (
                        1, 
                        "Country 1"),
                    new (
                        2, 
                        "Country 2"),
                });
        
        modelBuilder.Entity<Province>()
            .HasData(
                new List<Province>
                {
                    new (
                        1, 
                        "Province 1.1",
                        1),
                    new (
                        2, 
                        "Province 1.2",
                        1),
                    new (
                        3, 
                        "Province 2.1",
                        2),
                    new (
                        4, 
                        "Province 2.2",
                        2),
                });
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies(IsUseLazyLoading)
            .UseSqlServer(
                ConnectionString,
                builder =>
                {
                    builder.EnableRetryOnFailure(30, TimeSpan.FromSeconds(2), null);
                });
    }
}