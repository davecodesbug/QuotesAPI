using System.ComponentModel.DataAnnotations;

namespace QuotesAPI.Model;

public class UpsertQuote
{
    [Required]
    public string? Quote { get; set; }
}