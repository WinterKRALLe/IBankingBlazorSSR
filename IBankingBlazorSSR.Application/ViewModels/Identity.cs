using System.ComponentModel.DataAnnotations;

namespace IBankingBlazorSSR.Application.ViewModels;

public class LoginViewModel
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class RegisterViewModel
{
    [Required] public string Name { get; set; } = null!;

    [Required] public string SurName { get; set; } = null!;

    [Required] [EmailAddress] public string Email { get; set; } = null!;

    [Required] [Phone] public string Phone { get; set; } = null!;

    [Required] public string Address { get; set; } = null!;

    [Required] public string UserName { get; set; } = null!;

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
        MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = null!;

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwords don't match!")]
    public string RepeatedPassword { get; set; } = null!;
}