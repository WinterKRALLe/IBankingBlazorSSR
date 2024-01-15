using IBankingBlazorSSR.Application.ViewModels;

namespace IBankingBlazorSSR.Application.Abstraction;

public interface IUserService
{
    Task<ProfileData> PopulateUserSettingsAsync();
    Task<bool> ChangePhoneAsync(PhoneViewModel model);
    Task<bool> ChangeUserInfoAsync(ProfileViewModel model);
    Task<bool> ChangeUserPasswordAsync(ChangePasswordViewModel model);
}