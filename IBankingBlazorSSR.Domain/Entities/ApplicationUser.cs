using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace IBankingBlazorSSR.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    [Key] public override string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Surname is required.")]
    public string Surname { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [ProtectedPersonalData]
    public override string Email { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [ProtectedPersonalData]
    public override string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Username is required.")]
    [ProtectedPersonalData]
    public override string UserName { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
    public string Password { get; set; } = string.Empty;
}