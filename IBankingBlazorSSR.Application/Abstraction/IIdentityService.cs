using IBankingBlazorSSR.Application.Implementation;
using IBankingBlazorSSR.Application.ViewModels;
using Microsoft.AspNetCore.Http;

namespace IBankingBlazorSSR.Application.Abstraction;

public interface IIdentityService
{
    Task<(bool Success, string ErrorMessage)> LoginUserAsync(string username, string password);
    Task<bool> RegisterUser(RegisterViewModel inputRegister);
    Task<bool> LogoutUserAsync(HttpContext httpContext);
}