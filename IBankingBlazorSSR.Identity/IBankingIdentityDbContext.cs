using IBankingBlazorSSR.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IBankingBlazorSSR.Identity;

public class IBankingIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public IBankingIdentityDbContext(DbContextOptions<IBankingIdentityDbContext> options)
        : base(options)
    {
        
    }
}