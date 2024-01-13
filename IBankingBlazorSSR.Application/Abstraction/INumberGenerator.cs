namespace IBankingBlazorSSR.Application.Abstraction;

public interface INumberGenerator
{
    string GenerateAccountNumber(Guid usedId);
    string GenerateCardNumber(Guid userId);
    string GenerateCVV();
}