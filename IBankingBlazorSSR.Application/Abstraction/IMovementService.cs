using IBankingBlazorSSR.Application.ViewModels;

namespace IBankingBlazorSSR.Application.Abstraction;

public interface IMovementService
{
    Task<bool> ProcessPaymentAsync(MovementViewModel inputPayment);
}