using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestApi.Dtos;
using RestApi.Models;

namespace RestApi
{
    public static class Extensions
    {
        public static ExpenseDto  AsDto(this Expense expense){
            return new ExpenseDto{
                Id=expense.Id,
                Description=expense.Description,
                Category=expense.Category,
                Amount=expense.Amount,
                Date=expense.Date
            };
        }

        public static IncomeDto  AsDto(this Income income){
            return new IncomeDto{
                Id=income.Id,
                Description=income.Description,
                Category=income.Category,
                Amount=income.Amount,
                Date=income.Date
            };
        }
    }
}