using Microsoft.AspNetCore.Identity;

namespace IBankingBlazorSSR.Infrastructure.Identity;

public sealed class ApplicationUser : IdentityUser<Guid>
{
    public string? Name { get; set; }
    public string? SurName { get; set; }
    public string? Address { get; set; }
    
}