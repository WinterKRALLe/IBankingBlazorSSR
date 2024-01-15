namespace IBankingBlazorSSR.Application.Abstraction;

public interface ILoginService
{
    Task<(bool Success, string ErrorMessage)> LoginUserAsync(string username, string password);
}