using IBankingBlazorSSR.Application.Abstraction;
using IBankingBlazorSSR.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace IBankingBlazorSSR.Application.Implementation;

public class LoginService(SignInManager<ApplicationUser> signManager) : ILoginService
{
    public async Task<(bool Success, string ErrorMessage)> LoginUserAsync(string username, string password)
    {
        var result = await signManager.PasswordSignInAsync(username, password, false, false);

        if (result.Succeeded)
        {
            return (true, string.Empty);
        }

        if (result.RequiresTwoFactor)
        {
            return (false, "requiresTwoFactor");
        }

        if (result.IsLockedOut)
        {
            return (false, "locked");
        }

        if (result.IsNotAllowed)
        {
            return (false, "notAllowed");
        }

        return (false, "Invalid username or password");
    }
}