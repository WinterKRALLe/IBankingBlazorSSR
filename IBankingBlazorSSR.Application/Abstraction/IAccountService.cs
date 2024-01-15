using IBankingBlazorSSR.Application.Implementation;

namespace IBankingBlazorSSR.Application.Abstraction;

public interface IAccountService
{
    Task<AccountService.UserData> GetUserDataAsync();
    Task<AccountService.InputAddCardModel> InitializeAddCardModelAsync();
    Task AddCardAsync(AccountService.InputAddCardModel inputAddCard);
}