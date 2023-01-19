using System.ComponentModel.DataAnnotations;

namespace QuotesAPI.Model;

public class AddQuote
{
    [Required]
    public string? Quote { get; set; }
}