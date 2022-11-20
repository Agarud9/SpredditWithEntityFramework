using Microsoft.EntityFrameworkCore;
using SharedDomain.Models;

namespace EfcDataAccess;

public class FileContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Vote> Votes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Spreddit.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.Username);
        modelBuilder.Entity<Vote>().HasKey(vote => new { vote.Username, vote.Type, vote.PostId});
        //modelBuilder.Entity<Vote>().HasNoKey();
    }
}