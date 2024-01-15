using IBankingBlazorSSR.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IBankingBlazorSSR.Infrastructure.Identity;

public sealed class UserAccessor(
    IHttpContextAccessor httpContextAccessor,
    UserManager<ApplicationUser> userManager)
{
    public async Task<ApplicationUser> GetRequiredUserAsync()
    {
        var principal = httpContextAccessor.HttpContext?.User ??
                        throw new InvalidOperationException(
                            $"{nameof(GetRequiredUserAsync)} requires access to an {nameof(HttpContext)}.");

        var user = await userManager.GetUserAsync(principal);

        if (user != null) return user;
        return null!;
    }
}