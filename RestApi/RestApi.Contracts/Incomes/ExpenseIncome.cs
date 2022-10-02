namespace RestApi.Contracts.Incomes
{
    public record IncomeResponse(
        Guid Id,
        string Description,
        string Category,
        decimal Amount,
        DateTimeOffset Date
    );
}