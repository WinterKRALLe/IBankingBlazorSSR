using System.ComponentModel.DataAnnotations;
using IBankingBlazorSSR.Application.Abstraction;
using IBankingBlazorSSR.Domain.Entities;
using IBankingBlazorSSR.Infrastructure.Database;
using IBankingBlazorSSR.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;

namespace IBankingBlazorSSR.Application.Implementation;

public class AccountService(MyIdentityDbContext context, UserAccessor userAccessor, INumberGenerator numberGenerator)
    : IAccountService
{
    public async Task<UserData> GetUserDataAsync()
    {
        var user = await userAccessor.GetRequiredUserAsync();
        var accounts = await context.Accounts.Where(c => c.UserId == user.Id).ToListAsync();
        var cards = await context.Cards.Where(c => c.UserId == user.Id).ToListAsync();
        var cardCount = cards.Count;

        var myAccountNumber = GetAccountNumberForUser(user.Id);

        var movements = context.Movements
            .Where(m => m.AccountNumberFrom == myAccountNumber || m.AccountNumberTo == myAccountNumber)
            .ToList();

        return new UserData
        {
            User = user,
            Accounts = accounts,
            Cards = cards,
            CardCount = cardCount,
            MyAccountNumber = myAccountNumber,
            Movements = movements
        };
    }

    private string GetAccountNumberForUser(Guid userId)
    {
        var account = context.Accounts.FirstOrDefault(a => a.UserId == userId);
        return account?.AccountNumber ?? "";
    }

    public class UserData
    {
        public ApplicationUser User { get; set; } = default!;
        public List<Account> Accounts { get; set; } = new();
        public List<Card> Cards { get; set; } = new();
        public int CardCount { get; set; }
        public string MyAccountNumber { get; set; } = "";
        public List<Movement> Movements { get; set; } = new();
    }

    public async Task<InputAddCardModel> InitializeAddCardModelAsync()
    {
        var user = await userAccessor.GetRequiredUserAsync();

        int cardCount = await context.Cards.CountAsync(card => card.UserId == user.Id);
        if (cardCount == 3)
        {
            throw new InvalidOperationException("User already has the maximum number of cards.");
        }

        var cardNumber = numberGenerator.GenerateCardNumber(user.Id);
        var holder = $"{user.Name} {user.SurName}";
        var expiration = GenerateExpirationDate();
        var cvv = numberGenerator.GenerateCVV();

        return new InputAddCardModel
        {
            CardNumber = cardNumber,
            Holder = holder,
            Expiration = expiration,
            Cvv = cvv,
            State = true
        };
    }

    public async Task AddCardAsync(InputAddCardModel inputAddCard)
    {
        var user = await userAccessor.GetRequiredUserAsync();

        var card = new Card
        {
            CardNumber = inputAddCard.CardNumber,
            Holder = inputAddCard.Holder,
            Expiration = inputAddCard.Expiration,
            CVV = inputAddCard.Cvv,
            State = inputAddCard.State,
            UserId = user.Id
        };

        context.Cards.Add(card);
        await context.SaveChangesAsync();
    }

    private string GenerateExpirationDate()
    {
        DateTime currentDate = DateTime.Now;
        DateTime expirationDate = currentDate.AddYears(5);

        string formattedDate = $"{expirationDate.Month:D2} / {expirationDate.Year % 100:D2}";
        return formattedDate;
    }

    public class InputAddCardModel
    {
        [Required] public string CardNumber { get; set; } = null!;
        [Required] public string Holder { get; set; } = null!;
        [Required] public string Expiration { get; set; } = null!;
        [Required] public string Cvv { get; set; } = null!;
        [Required] public bool State { get; set; } = true;
    }
}