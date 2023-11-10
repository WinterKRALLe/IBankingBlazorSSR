using IBankingBlazorSSR.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IBankingBlazorSSR.Infrastructure.Database;

// public class MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options) :
//     IdentityUserContext<ApplicationUser>(options);

public class MyIdentityDbContext : IdentityDbContext
{
    public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options)
        : base(options)
    {
    }
    public DbSet<ApplicationUser>? AppUsers { get; set; }
}