using IBankingBlazorSSR.Application.ViewModels;

namespace IBankingBlazorSSR.Application.Abstraction;

public interface IAccountService
{
    Task<string[]> Register(RegisterViewModel vm);
}