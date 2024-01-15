using System.ComponentModel.DataAnnotations;

namespace IBankingBlazorSSR.Application.ViewModels;

public class MovementViewModel
{
    [Required(ErrorMessage = "AccountNumberFrom is required.")]
    public string AccountNumberFrom { get; set; } = null!;

    [Required(ErrorMessage = "AccountNumberTo is required.")]
    public string AccountNumberTo { get; set; } = null!;

    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Please enter a valid amount.")]
    public decimal Amount { get; set; }

    public string? Message { get; set; }
}