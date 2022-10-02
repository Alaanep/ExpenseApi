using ErrorOr;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.ServiceErrors;

namespace RestApi.Services
{
    public class ExpenseRepo:  IExpenseService{

        private DataContext? _context;

        public ExpenseRepo(DataContext context){
            _context=context;
        }

        public async Task CreateItemAsync(Expense expense){
            await _context._expenses.AddAsync(expense);
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {   
            var dbExpense = await _context._expenses.FirstOrDefaultAsync(e=> e.Id==id);
            _context._expenses.Remove(dbExpense);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
            
        }

        public async Task<Expense> GetItemAsync(Guid id){
            var expense=  await _context._expenses.FirstOrDefaultAsync(e=> e.Id==id);
            return await Task.FromResult<Expense>(expense);
        }
        
        public async Task<IEnumerable<Expense>> GetItemsAsync()
        {
            return await Task.FromResult<IEnumerable<Expense>>(_context._expenses);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Expense expense)
        {   
            _context._expenses.Update(expense);
            await _context.SaveChangesAsync();
        }


        // public ErrorOr<Created> CreateExpense(Expense expense)
        // {   
        //     var dbExpense  = _context._expenses?.Find(expense.Id);
        //     if(dbExpense is not null){
        //         _context._expenses.Add(dbExpense);
        //         _context.SaveChanges();
        //     }
        //     return  Result.Created;
        // }

        // public ErrorOr<Deleted> DeleteExpense(Guid id)
        // {   
        //     var dbExpense  = _context._expenses?.Find(id);
        //     if(dbExpense is not null){
        //         _context._expenses.Remove(dbExpense);
        //         _context.SaveChanges();
        //     }
        //     return Result.Deleted;
        // }

        // public ErrorOr<Expense> GetExpense(Guid id)
        // {   

        //     var dbExpense = _context._expenses.FirstOrDefault(e=> e.Id==id);
        //     if(dbExpense is not null){
        //         return dbExpense;
        //     }
        //     return Errors.Expense.NotFound;
        // }

        // public ErrorOr<UpsertedExpense> UpsertExpense(Expense expense)
        // {   

        //     var isNewlyCreated = !_context._expenses.Any(e=>e.Id==expense.Id);
        //     _context._expenses.Update(expense);
        //     //_expenses[expense.Id]=expense;


        //     return new UpsertedExpense(isNewlyCreated);
        // }
    }
}