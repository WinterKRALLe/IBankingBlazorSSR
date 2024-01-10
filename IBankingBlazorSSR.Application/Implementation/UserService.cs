using IBankingBlazorSSR.Application.Abstraction;
using IBankingBlazorSSR.Infrastructure.Database;
using IBankingBlazorSSR.Infrastructure.Identity;

namespace IBankingBlazorSSR.Application.Implementation;

public class UserService(MyIdentityDbContext context) : IUserService
{
    public async Task UpdateUserAsync(ApplicationUser user)
    {
        context.Update(user);
        await context.SaveChangesAsync();
    }
}