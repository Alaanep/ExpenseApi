using ErrorOr;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.ServiceErrors;

namespace RestApi.Services
{
    public class ExpenseRepo:  IExpenseService{

        private readonly DataContext _context;

        public ExpenseRepo(DataContext context){
            _context=context;
        }

        public ErrorOr<Created> CreateExpense(Expense expense)
        {   
            var dbExpense  = _context._expenses?.Find(expense.Id);
            if(dbExpense is not null){
                _context._expenses.Add(dbExpense);
                _context.SaveChanges();
            }
            return  Result.Created;
        }

        public ErrorOr<Deleted> DeleteExpense(Guid id)
        {   
            var dbExpense  = _context._expenses?.Find(id);
            if(dbExpense is not null){
                _context._expenses.Remove(dbExpense);
                _context.SaveChanges();
            }
            return Result.Deleted;
        }

        public ErrorOr<Expense> GetExpense(Guid id)
        {   
            
            var dbExpense = _context._expenses.FirstOrDefault(e=> e.Id==id);
            if(dbExpense is not null){
                return dbExpense;
            }
            return Errors.Expense.NotFound;
        }

        public ErrorOr<UpsertedExpense> UpsertExpense(Expense expense)
        {   

            var isNewlyCreated = !_context._expenses.Any(e=>e.Id==expense.Id);
            _context._expenses.Update(expense);
            //_expenses[expense.Id]=expense;
            

            return new UpsertedExpense(isNewlyCreated);
        }
    }
}