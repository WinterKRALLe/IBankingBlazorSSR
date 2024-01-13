using IBankingBlazorSSR.Application.Abstraction;

namespace IBankingBlazorSSR.Application.Implementation;

public class NumberGenerator : INumberGenerator
{
    public string GenerateAccountNumber(Guid userId)
    {
        long numericUserId = BitConverter.ToInt64(userId.ToByteArray(), 0);

        string accountNumber = (numericUserId % 1000000000).ToString("D9");

        return accountNumber;
    }

    public string GenerateCardNumber(Guid userId)
    {
        long numericUserId = BitConverter.ToInt64(userId.ToByteArray(), 0);

        long currentDateTime = DateTime.Now.Ticks;

        long combinedNumber = Math.Abs((numericUserId * 100000000000000) + (currentDateTime % 100000000000000));

        string uniqueNumber = (combinedNumber % 10000000000000000).ToString("D16");

        string number = uniqueNumber;
        uniqueNumber = string.Join(" ", Enumerable.Range(0, uniqueNumber.Length / 4)
            .Select(i => number.Substring(i * 4, 4)));

        return uniqueNumber;
    }

    
    public string GenerateCVV()
    {
        Random random = new Random();
        return random.Next(100, 1000).ToString();
    }

}