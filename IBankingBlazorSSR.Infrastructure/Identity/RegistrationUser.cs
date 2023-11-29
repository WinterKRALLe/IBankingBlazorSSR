using Microsoft.AspNetCore.Identity;

namespace IBankingBlazorSSR.Infrastructure.Identity;

public class RegistrationUser : IdentityUser<Guid>
{
    public virtual string Name { get; set; }
    public virtual string SurName { get; set; }
    public override string Email { get; set; }
    public override string PhoneNumber { get; set; }
    public virtual string Address { get; set; }
    public override string UserName { get; set; }
}