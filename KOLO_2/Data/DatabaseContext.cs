using KOLO_2.Models;
using Microsoft.EntityFrameworkCore;

namespace KOLO_2.Data;


public class DatabaseContext : DbContext
{
    protected DatabaseContext() {}
    public DatabaseContext(DbContextOptions options) : base(options) {}

    public DbSet<Item> Items { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item {
                Id = 1,
                Name = "item1",
                Weight = 11,
            },
            new Item {
                Id = 2,
                Name = "item2",
                Weight = 11,
            },
            new Item {
                Id = 3,
                Name = "item3",
                Weight = 5,
            },
        });
        
        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character {
                Id = 1,
                FirstName = "str_3",
                LastName = "str_4",
                CurrentWeight = 12,
                MaxWeight = 1000,
            },
        });
        
        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title {
                Id = 1,
                Name = "something"
            },
            new Title {
                Id = 2,
                Name = "sth2"
            },
        });
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack {
                Id = 1,
                Amount = 22,
                IdItem = 1,
                IdCharacter = 1,
            },
        });
        
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>
        {
            new CharacterTitle {
                CharacterId = 1,
                TitleId = 1,
                AcquiredAt = DateTime.Parse("2000-01-01")
            },
            new CharacterTitle {
                CharacterId = 1,
                TitleId = 2,
                AcquiredAt = DateTime.Parse("2000-01-02")
            },
        });
        
    }
}

