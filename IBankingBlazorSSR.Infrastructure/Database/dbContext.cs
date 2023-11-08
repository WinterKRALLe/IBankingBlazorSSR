using Microsoft.EntityFrameworkCore;

namespace IBankingBlazorSSR.Infrastructure.Database;

public class dbContext : DbContext
{
    public dbContext(DbContextOptions<dbContext> options) : base(options)
    {
        
    }
    
}