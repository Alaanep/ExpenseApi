using RestApi.Models;
using ErrorOr;
using RestApi.ServiceErrors;

namespace RestApi.Services
{
    public class ExpenseService: IExpenseService{
        private static readonly Dictionary<Guid, Expense> _expenses = new();

        public ErrorOr<Created> CreateExpense(Expense expense)
        {
            _expenses.Add(expense.Id, expense);
            return  Result.Created;
        }

        public ErrorOr<Deleted> DeleteExpense(Guid id)
        {
            _expenses.Remove(id);
            return Result.Deleted;
        }

        public ErrorOr<Expense> GetExpense(Guid id)
        {   
            if(_expenses.TryGetValue(id, out var expense)){
                return expense;
            }
            return Errors.Expense.NotFound;
        }

        public ErrorOr<UpsertedExpense> UpsertExpense(Expense expense)
        {
            var isNewlyCreated = !_expenses.ContainsKey(expense.Id);
            _expenses[expense.Id]=expense;

            return new UpsertedExpense(isNewlyCreated);
        }
    }
}