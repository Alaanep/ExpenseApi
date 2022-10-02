using RestApi.Models;
using ErrorOr;

namespace RestApi.Services
{
    public interface IExpenseService
    {   
        Task<Expense> GetItemAsync(Guid id);
        Task<IEnumerable<Expense>> GetItemsAsync();
        Task CreateItemAsync(Expense expense);
        Task UpdateItemAsync(Expense expense);
        Task DeleteItemAsync(System.Guid id);
        // ErrorOr<Created> CreateExpense(Expense expense);
        // ErrorOr<Expense> GetExpense(Guid id);
        // ErrorOr<UpsertedExpense> UpsertExpense(Expense expense);
        // ErrorOr<Deleted> DeleteExpense(Guid id);
    }
}