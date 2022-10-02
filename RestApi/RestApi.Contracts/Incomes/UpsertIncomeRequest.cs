namespace RestApi.Contracts.Incomes
{
    public record UpsertIncomeRequest(
        string Description,
        string Category,
        decimal Amount,
        DateTimeOffset Date
    );
}