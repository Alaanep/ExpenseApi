namespace RestApi.Contracts.Expenses
{
    public record CreateExpenseRequest(
        string Description,
        string Category,
        decimal Amount,
        DateTimeOffset Date
    );
        
    
}