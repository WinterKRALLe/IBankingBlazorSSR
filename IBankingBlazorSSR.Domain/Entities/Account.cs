using Microsoft.EntityFrameworkCore;

namespace IBankingBlazorSSR.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string Currency { get; set; }
    [Precision(14, 2)]
    public decimal Balance { get; set; }
    public string AccountNumber { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}