using KOLO_2.Models;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext() {}
    public DatabaseContext(DbContextOptions options) : base(options) {}
    
    public DbSet<A> As { get; set; }
    public DbSet<B> Bs { get; set; }
    public DbSet<C> Cs { get; set; }
    
    public DbSet<AB> ABs { get; set; }
    public DbSet<ABC> ABCs { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<A>().HasData(new List<A>
        {
            new A {
                Id = 1,
                LastName = "aaa1"
            },
            new A {
                Id = 2,
                LastName = "aaa2"
            },
        });
        
        modelBuilder.Entity<B>().HasData(new List<B>
        {
            new B {
                Id = 1
            },
            new B {
                Id = 2
            },
        });
        
        modelBuilder.Entity<C>().HasData(new List<C>
        {
            new C {
                Id = 1,
                Name = "one"
            },
            new C {
                Id = 2,
                Name = "two"
            },
            new C {
                Id = 3,
                Name = "three"
            }
        });
        
        modelBuilder.Entity<AB>().HasData(new List<AB>
        {
            new AB
            {
                Id = 1,
                IdA = 1,
                IdB = 2
            },
            new AB
            {
                Id = 2,
                IdA = 1,
                IdB = 1
            },
            new AB
            {
                Id = 3,
                IdA = 2,
                IdB = 1
            }
        });
        
        
        modelBuilder.Entity<ABC>().HasData(new List<ABC>
        {
            new ABC
            {
                IdAB = 1,
                IdC = 1,
            },
            new ABC
            {
                IdAB = 1,
                IdC = 3,
            },
            new ABC
            {
                IdAB = 2,
                IdC = 2,
            },
            new ABC
            {
                IdAB = 2,
                IdC = 1,
            }
        });
    }
}
