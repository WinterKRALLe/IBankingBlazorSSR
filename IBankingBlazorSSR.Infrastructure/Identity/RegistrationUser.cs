using Microsoft.AspNetCore.Identity;

namespace IBankingBlazorSSR.Infrastructure.Identity;

public sealed class RegistrationUser : IdentityUser<Guid>
{
    public string? Name { get; set; }
    public string? SurName { get; set; }
    public override string? Email { get; set; }
    public override string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public override string? UserName { get; set; }
}