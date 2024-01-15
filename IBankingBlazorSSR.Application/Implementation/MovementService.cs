using IBankingBlazorSSR.Application.Abstraction;
using IBankingBlazorSSR.Application.ViewModels;
using IBankingBlazorSSR.Domain.Entities;
using IBankingBlazorSSR.Infrastructure.Database;
using IBankingBlazorSSR.Infrastructure.Identity;
using Microsoft.IdentityModel.Tokens;

namespace IBankingBlazorSSR.Application.Implementation;

public class MovementService(MyIdentityDbContext context, UserAccessor userAccessor) : IMovementService
{
    public async Task<bool> ProcessPaymentAsync(MovementViewModel inputPayment)
    {
        if (inputPayment.AccountNumberTo.IsNullOrEmpty() || inputPayment.Amount == 0)
        {
            return false;
        }

        var user = await userAccessor.GetRequiredUserAsync();

        var account = context.Accounts
            .First(a => a.UserId == user.Id);

        var accountTo = context.Accounts
            .FirstOrDefault(a => a.AccountNumber == inputPayment.AccountNumberTo);

        var payment = new Movement
        {
            AccountNumberFrom = inputPayment.AccountNumberFrom,
            AccountNumberTo = inputPayment.AccountNumberTo,
            Amount = Convert.ToDecimal(inputPayment.Amount),
            Message = inputPayment.Message,
            SentAt = DateTime.Now,
        };

        context.Movements.Add(payment);
        account.Balance -= Convert.ToDecimal(inputPayment.Amount);

        if (accountTo is not null)
        {
            accountTo.Balance += Convert.ToDecimal(inputPayment.Amount);
        }

        var affectedRows = await context.SaveChangesAsync();

        return affectedRows > 1;
    }
}