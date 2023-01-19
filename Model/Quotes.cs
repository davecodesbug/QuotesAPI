using System.ComponentModel.DataAnnotations;

namespace QuotesAPI.Model;

public class Quotes
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string? Quote { get; set; }
}