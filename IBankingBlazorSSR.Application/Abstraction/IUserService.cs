using IBankingBlazorSSR.Infrastructure.Identity;

namespace IBankingBlazorSSR.Application.Abstraction;

public interface IUserService
{
    Task UpdateUserAsync(ApplicationUser user);
}