namespace IBankingBlazorSSR.Domain.Entities;

public class Card
{
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string Holder { get; set; }
    public string Expiration { get; set; }
    public string CVV { get; set; }
    public bool State { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}