// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using ErrorOr;
// using RestApi.Models;
// using RestApi.ServiceErrors;

// namespace RestApi.Services{
//     public class IncomeService : IIncomeService{

//         private static readonly Dictionary<Guid, Income> _incomes = new();
//         public ErrorOr<Created> CreateIncome(Income income)
//         {
//             _incomes.Add(income.Id, income);
//             return  Result.Created;
//         }

//         public ErrorOr<Deleted> DeleteIncome(Guid id){
//             _incomes.Remove(id);
//             return Result.Deleted;
//         }

//         public ErrorOr<Income> GetIncome(Guid id)
//         {
//             if(_incomes.TryGetValue(id, out var income)){
//                 return income;
//             }
//             return Errors.Income.NotFound;
//         }

//         public ErrorOr<UpsertedIncome> UpsertIncome(Income income)
//         {
//             var isNewlyCreated = !_incomes.ContainsKey(income.Id);
//             _incomes[income.Id]=income;

//             return new UpsertedIncome(isNewlyCreated);
//         }
//     }
// }