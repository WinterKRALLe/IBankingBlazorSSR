using IBankingBlazorSSR.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IBankingBlazorSSR.Infrastructure.Database;

public class MyIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Card>()
            .HasOne(model => model.ApplicationUser)
            .WithMany(model => model.Cards)
            .HasForeignKey(model => model.UserId);
        
        builder.Entity<Account>()
            .HasOne(model => model.ApplicationUser)
            .WithMany(model => model.Accounts)
            .HasForeignKey(model => model.UserId);
    }

    public DbSet<Card> Cards { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Movement> Movements { get; set; }
}
