using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IBankingBlazorSSR.Infrastructure.Identity;

public class UserAccessor(
    IHttpContextAccessor httpContextAccessor,
    UserManager<RegistrationUser> userManager)
{
    public async Task<RegistrationUser> GetRequiredUserAsync()
    {
        var principal = httpContextAccessor.HttpContext?.User ??
                        throw new InvalidOperationException(
                            $"{nameof(GetRequiredUserAsync)} requires access to an {nameof(HttpContext)}.");
        var user = await userManager.GetUserAsync(principal);
        if (user is null)
        {
            httpContextAccessor.HttpContext.Response.Redirect("/Identity/InvalidUser");
            // status: Error: Unable to load user with ID '{userManager.GetUserId(principal)}'.
        }
        
        return user;
    }
}