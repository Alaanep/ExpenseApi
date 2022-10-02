using RestApi.Models;
using ErrorOr;

namespace RestApi.Services
{
    public interface IExpenseService
    {
        ErrorOr<Created> CreateExpense(Expense expense);
        ErrorOr<Expense> GetExpense(Guid id);
        ErrorOr<UpsertedExpense> UpsertExpense(Expense expense);
        ErrorOr<Deleted> DeleteExpense(Guid id);
    }
}