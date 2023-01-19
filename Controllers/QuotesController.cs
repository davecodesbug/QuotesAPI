using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuotesAPI.Database;
using QuotesAPI.Model;

namespace QuotesAPI.Controllers;

[ApiController]
[Route("api/quotes/")]
public class QuotesController : Controller
{
    private readonly QuotesContext _dbContext;

    public QuotesController(QuotesContext dbContext)
    {
        this._dbContext = dbContext;
    }
    
    // Get all quotes from Database
    [HttpGet]
    public async Task<IActionResult> GetQuotes()
    {
        var quote = await _dbContext.Quotes.ToListAsync();
        return Ok(quote);
    }
    
    // Get one quote from Database
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetQuote([FromRoute] Guid id)
    {
        var quote = await _dbContext.Quotes.FindAsync(id);
        
        if (quote != null)
        {
            return Ok(quote);
        }
        
        return NotFound();
    }

    // Post quote to Database
    [HttpPost]
    public async Task<IActionResult> AddQuote(AddQuote addQuote)
    {
        var quote = new Quotes()
        {
            Id = Guid.NewGuid(),
            Quote = addQuote.Quote
        };

        await _dbContext.Quotes.AddAsync(quote);
        await _dbContext.SaveChangesAsync();

        return Ok(quote);
    }
    
    // Patch/Edit quote in Database
    [HttpPatch]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpsertQuote([FromRoute] Guid id, UpsertQuote upsertQuote)
    {
        var quote = await _dbContext.Quotes.FindAsync(id);

        if (quote != null)
        {
            quote.Quote = upsertQuote.Quote;
            await _dbContext.SaveChangesAsync();
            return Ok(quote);
        }

        return NotFound();
    }

    // Delete quote from Database
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteQuote([FromRoute] Guid id)
    {
        var quote = await _dbContext.Quotes.FindAsync(id);
        
        if (quote != null)
        {
            _dbContext.Remove(quote);
            await _dbContext.SaveChangesAsync();
            return Ok(quote);
        }
        
        return NotFound();
    }
}