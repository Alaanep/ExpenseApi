namespace RestApi.Contracts.Expenses
{
    public record UpsertExpenseRequest(
        string Description,
        string Category,
        decimal Amount,
        DateTimeOffset Date
    );
}