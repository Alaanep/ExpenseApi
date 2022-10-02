using System.ComponentModel.DataAnnotations;
namespace RestApi.Dtos{
    public record UpdateIncomeDto{
        [Required]public string Description { get; init;}
        [Required]public string Category { get; init;}
        [Required]public decimal Amount { get; init;}
        [Required]public DateTimeOffset Date { get; init;}
    }
}