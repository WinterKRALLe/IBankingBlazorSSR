using IBankingBlazorSSR.Application.Abstraction;
using IBankingBlazorSSR.Application.ViewModels;
using IBankingBlazorSSR.Domain.Entities;
using IBankingBlazorSSR.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace IBankingBlazorSSR.Application.Implementation;

public class UserService(
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    UserAccessor userAccessor)
    : IUserService
{
    public async Task<ProfileData> PopulateUserSettingsAsync()
    {
        var user = await userAccessor.GetRequiredUserAsync();

        var profileModel = new ProfileViewModel
        {
            Name = user.Name,
            SurName = user.SurName,
            Email = user.Email,
            Address = user.Address
        };

        var phoneModel = new PhoneViewModel
        {
            PhoneNumber = await userManager.GetPhoneNumberAsync(user)
        };

        return new ProfileData
        {
            ProfileModel = profileModel,
            PhoneModel = phoneModel
        };
    }

    public async Task<bool> ChangePhoneAsync(PhoneViewModel model)
    {
        var user = await userAccessor.GetRequiredUserAsync();

        var setPhoneResult = await userManager.SetPhoneNumberAsync(user, model.PhoneNumber);

        if (!setPhoneResult.Succeeded) return false;
        try
        {
            await signInManager.RefreshSignInAsync(user);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during RefreshSignInAsync: {ex.Message}");
        }

        return false;
    }

    public async Task<bool> ChangeUserInfoAsync(ProfileViewModel model)
    {
        var user = await userAccessor.GetRequiredUserAsync();

        user.Name = model.Name;
        user.SurName = model.SurName;
        user.Email = model.Email;
        user.Address = model.Address;

        var result = await userManager.UpdateAsync(user);

        if (!result.Succeeded) return false;
        try
        {
            await signInManager.RefreshSignInAsync(user);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during RefreshSignInAsync: {ex.Message}");
        }

        return false;
    }

    public async Task<bool> ChangeUserPasswordAsync(ChangePasswordViewModel model)
    {
        var user = await userAccessor.GetRequiredUserAsync();

        var changePasswordResult =
            await userManager.ChangePasswordAsync(user, model.CurrentPassword!, model.NewPassword!);

        if (!changePasswordResult.Succeeded) return false;
        try
        {
            await signInManager.RefreshSignInAsync(user);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during RefreshSignInAsync: {ex.Message}");
        }

        return false;
    }
}