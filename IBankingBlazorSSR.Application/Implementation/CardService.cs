using System.ComponentModel.DataAnnotations;
using IBankingBlazorSSR.Domain.Entities;
using IBankingBlazorSSR.Infrastructure.Database;

namespace IBankingBlazorSSR.Application.Implementation;

public class CardService(MyIdentityDbContext context)
{
    public void AddCard(Card model)
    {
        context.Cards.Add(model);
        context.SaveChangesAsync();
    }
}