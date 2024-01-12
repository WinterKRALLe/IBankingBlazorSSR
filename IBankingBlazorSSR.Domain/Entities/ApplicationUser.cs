using Microsoft.AspNetCore.Identity;

namespace IBankingBlazorSSR.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string? Name { get; set; }
    public string? SurName { get; set; }
    public string? Address { get; set; }
    public IList<Card> Cards { get; }
    public IList<Account> Accounts { get; }
}