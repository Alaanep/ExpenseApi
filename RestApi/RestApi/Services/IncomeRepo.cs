using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using RestApi.ServiceErrors;

namespace RestApi.Services
{
    public class IncomeRepo: DbContext, IIncomeService{

         private DataContext _context;

        public IncomeRepo(DataContext context){
            _context=context;
        }

        public async Task CreateItemAsync(Income income){
            await _context._incomes.AddAsync(income);
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {   
            var dbExpense = await _context._incomes.FirstOrDefaultAsync(e=> e.Id==id);
            _context._incomes.Remove(dbExpense);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Income> GetItemAsync(Guid id){
            var income =await _context._incomes.FirstOrDefaultAsync(e=> e.Id==id);
            return await Task.FromResult<Income>(income);    
        }
             
        public async Task<IEnumerable<Income>> GetItemsAsync(){
            return await Task.FromResult<IEnumerable<Income>>(_context._incomes);}

        public async Task UpdateItemAsync(Income income)
        {   
            _context._incomes.Update(income);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        

        // public ErrorOr<Created> CreateIncome(Income income)
        // {   
        //     var dbIncome  = _context._incomes?.Find(income?.Id);
        //     if(dbIncome is not null){
        //         _context._incomes.Add(dbIncome);
        //         _context.SaveChanges();
        //     }
        //     return  Result.Created;
        // }

        // public ErrorOr<Deleted> DeleteIncome(Guid id)
        // {   
        //     var dbIncome  = _context._incomes?.Find(id);
        //     if(dbIncome is not null){
        //         _context._incomes.Remove(dbIncome);
        //         _context.SaveChanges();
        //     }
        //     return Result.Deleted;
        // }

        // public ErrorOr<Income> GetIncome(Guid id)
        // {   
        //     var dbIncome = _context._incomes.FirstOrDefault(e=> e.Id==id);
        //     if(dbIncome is not null){
        //         return dbIncome;
        //     }
        //     return Errors.Expense.NotFound;
        // }

        // public ErrorOr<UpsertedIncome> UpsertIncome(Income income)
        // {   

        //     var isNewlyCreated = !_context._incomes.Any(e=>e.Id==income.Id);
        //     _context._incomes.Update(income);
        //     //_incomes[income.Id]=income;


        //     return new UpsertedIncome(isNewlyCreated);
        // }
    }
}