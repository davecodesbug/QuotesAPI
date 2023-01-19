using Microsoft.EntityFrameworkCore;
using QuotesAPI.Model;

namespace QuotesAPI.Database;

public class QuotesContext : DbContext
{
    public QuotesContext(DbContextOptions options) : base(options){}
    public  DbSet<Quotes> Quotes { get; set; } = null!;
    
}