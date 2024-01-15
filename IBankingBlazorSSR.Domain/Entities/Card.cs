using System.ComponentModel.DataAnnotations;

namespace IBankingBlazorSSR.Domain.Entities;

public class Card
{
    public int Id { get; set; }
    [Required]
    public string CardNumber { get; set; }

    [Required]
    public string Holder { get; set; }

    [Required]
    public string Expiration { get; set; }

    [Required]
    public string CVV { get; set; }
    public bool State { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}