using System.ComponentModel.DataAnnotations;

namespace IBankingBlazorSSR.Application.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string? Name { get; set; }
    
    [Required]
    public string? SurName { get; set; }

    [Required]
    public string? Email { get; set; }
    
    [Required]
    public string? Phone { get; set; }

    [Required]
    public string? Address { get; set; }
    
    [Required]
    public string? UserName {get; set; }
    
    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = null!;

    // [Required]
    // [Compare(nameof(Password), ErrorMessage = "Passwords don't match!")]
    // public string? RepeatedPassword { get; set; }
}