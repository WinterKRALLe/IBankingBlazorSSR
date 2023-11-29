using IBankingBlazorSSR.Application.Abstraction;
using IBankingBlazorSSR.Application.ViewModels;
using IBankingBlazorSSR.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace IBankingBlazorSSR.Application.Implementation;

public class AccountService(UserManager<RegistrationUser> userManager) : IAccountService
{
    private readonly UserManager<RegistrationUser> _userManager = userManager;

    public async Task<string[]> Register(RegisterViewModel vm)
    {
        if (vm.Password == null)
        {
            return new[] { "nebude" };
        }

        RegistrationUser user = new RegistrationUser()
        {
            Name = vm.Name,
            SurName = vm.SurName,
            Email = vm.Email,
            PhoneNumber = vm.Phone,
            Address = vm.Address,
            UserName = vm.UserName,
        };

        var result = await userManager.CreateAsync(user, vm.Password);

        if (result.Succeeded)
        {
            return new string[0]; // Success
        }

        var errors = result.Errors.Select(e => e.Description).ToArray();
        return errors;
    }

    

    
}