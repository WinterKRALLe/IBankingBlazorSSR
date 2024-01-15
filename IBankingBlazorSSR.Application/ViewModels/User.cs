using System.ComponentModel.DataAnnotations;

namespace IBankingBlazorSSR.Application.ViewModels;

public sealed class ProfileViewModel
{
    public string? Name { get; set; }
    public string? SurName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}

public sealed class PhoneViewModel
{
    [Phone]
    [Display(Name = "Phone number")]
    public string? PhoneNumber { get; set; }
}

public sealed class ChangePasswordViewModel
{
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Current password")]
    public string? CurrentPassword { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
        MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "New password")]
    public string? NewPassword { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm new password")]
    [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; }
}

public sealed class ProfileData
{
    public ProfileViewModel ProfileModel { get; set; } = null!;
    public PhoneViewModel PhoneModel { get; set; } = null!;
}