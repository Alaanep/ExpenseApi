namespace RestApi.Contracts.Incomes
{
    public record CreateIncomeRequest(
        string Description,
        string Category,
        decimal Amount,
        DateTimeOffset Date
    );
        
    
}