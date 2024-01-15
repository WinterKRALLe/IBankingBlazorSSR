using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace IBankingBlazorSSR.Domain.Entities;

public class Movement
{
    public int Id { get; set; }
    [Required] public string? AccountNumberFrom { get; set; }
    [Required] public string? AccountNumberTo { get; set; }
    [Required] [Precision(14, 2)] public decimal Amount { get; set; }
    public string? Message { get; set; }
    public DateTime SentAt { get; set; }
}