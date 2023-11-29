using IBankingBlazorSSR.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IBankingBlazorSSR.Infrastructure.Database;

public class MyIdentityDbContext : IdentityDbContext<RegistrationUser, IdentityRole<Guid>, Guid>
{   
    public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext> options) : base(options) {}
}
