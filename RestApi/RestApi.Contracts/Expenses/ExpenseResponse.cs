namespace RestApi.Contracts.Expenses
{
    public record ExpenseResponse(
        Guid Id,
        string Description,
        string Category,
        decimal Amount,
        DateTimeOffset Date
    );
}