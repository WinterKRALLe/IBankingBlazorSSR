using IBankingBlazorSSR.Application.Abstraction;
using IBankingBlazorSSR.Application.ViewModels;
using IBankingBlazorSSR.Domain.Entities;
using IBankingBlazorSSR.Infrastructure.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IBankingBlazorSSR.Application.Implementation;

public class IdentityService(
    SignInManager<ApplicationUser> signInManager,
    UserManager<ApplicationUser> userManager,
    MyIdentityDbContext context,
    INumberGenerator numberGenerator) : IIdentityService
{
    public async Task<(bool Success, string ErrorMessage)> LoginUserAsync(string username, string password)
    {
        var result = await signInManager.PasswordSignInAsync(username, password, true, true);

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

    public async Task<bool> RegisterUser(RegisterViewModel inputRegister)
    {
        var user = CreateUser(inputRegister);

        var result = await userManager.CreateAsync(user, inputRegister.Password);

        if (!result.Succeeded) return false;
        var account = new Account
        {
            Type = "Osobní",
            Currency = "CZK",
            Balance = 500,
            AccountNumber = numberGenerator.GenerateAccountNumber(user.Id),
            UserId = user.Id
        };

        context.Accounts.Add(account);

        var savedChanges = await context.SaveChangesAsync();

        return savedChanges > 0;
    }

    private ApplicationUser CreateUser(RegisterViewModel inputRegister)
    {
        ApplicationUser user = new()
        {
            Name = inputRegister.Name,
            SurName = inputRegister.SurName,
            Email = inputRegister.Email,
            PhoneNumber = inputRegister.Phone,
            Address = inputRegister.Address,
            UserName = inputRegister.UserName,
        };
        return user;
    }

    public async Task<bool> LogoutUserAsync(HttpContext httpContext)
    {
        var user = httpContext.User;

        if (!signInManager.IsSignedIn(user)) return false;
        await signInManager.SignOutAsync();
        return true;
    }
}