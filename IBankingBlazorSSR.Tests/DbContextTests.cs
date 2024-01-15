using IBankingBlazorSSR.Application.Implementation;
using IBankingBlazorSSR.Domain.Entities;
using IBankingBlazorSSR.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace IBankingBlazorSSR.Tests;

public class DbContextTests
{
    [Fact]
    public void AddCard_ShouldAddCardToDatabase()
    {
        // Vytvoření konfigurace pro in-memory databázi pro účely testování.
        var optionsBuilder = new DbContextOptionsBuilder<MyIdentityDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var context = new MyIdentityDbContext(optionsBuilder.Options);

        // Inicializace služby pro práci s kartami.
        var repository = new CardService(context);

        // Přidání nové karty do databáze.
        repository.AddCard(new Card
        {
            CardNumber = "1254 0804 9957 4217",
            Holder = "Jonathan Barnes",
            Expiration = "01 / 29",
            CVV = "603",
            State = true,
            UserId = new Guid("cf29e2f5-3d8c-4be0-b0d2-08dbff09110b")
        });

        // Ověření, že v databázi je nyní přítomna právě jedna karta.
        Assert.Single(context.Cards);
    }

// Test ověřující, že pokud chybí povinné pole, metoda AddCard nedá kartu do databáze.
    [Fact]
    public void AddCard_WithoutRequiredField_ShouldNotAddCardToDatabase()
    {
        // Vytvoření konfigurace pro in-memory databázi pro účely testování.
        var optionsBuilder = new DbContextOptionsBuilder<MyIdentityDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString());
        var context = new MyIdentityDbContext(optionsBuilder.Options);

        // Inicializace služby pro práci s kartami.
        var repository = new CardService(context);

        // Přidání nové karty do databáze bez poskytnutí povinného pole (např. CardNumber).
        repository.AddCard(new Card
        {
            // CardNumber není poskytnuto, což je povinné pole.
            Holder = "Jonathan Barnes",
            Expiration = "01 / 29",
            CVV = "603",
            State = true,
            UserId = new Guid("cf29e2f5-3d8c-4be0-b0d2-08dbff09110b")
        });

        // Ověření, že v databázi nebyla žádná karta přidána.
        Assert.Empty(context.Cards);
    }
}