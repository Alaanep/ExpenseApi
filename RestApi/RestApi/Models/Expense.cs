using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using RestApi.Contracts.Expenses;
using RestApi.ServiceErrors;

namespace RestApi.Models
{
    public class Expense{

        public const  int MinCategoryLength=3;
        public const int MaxCategoryLength = 50;
        public const  int MinDescriptionLength=3;
        public const int MaxDescriptionLength = 50;
        public Guid Id {get; }
        public string Description {get; }
        public string Category {get; }
        public decimal Amount {get; }
        public DateTimeOffset Date{get ;}
        

        private Expense(
            Guid id,
            string description,
            string category,
            decimal amount,
            DateTimeOffset date

        ){
            Id=id;
            Description=description;
            Category=category;
            Amount=amount;
            Date=date;

        }

        public static ErrorOr<Expense> Create(
            string description,
            string category,
            decimal amount,
            DateTimeOffset date,
            Guid? id= null
        ){  
            List<Error> errors = new ();
            //enforce invariants
            if(category.Length is < MinCategoryLength or >  MaxCategoryLength){
                errors.Add(Errors.Expense.InvalidName);
            }

            if(description.Length is < MinDescriptionLength or > MaxDescriptionLength){
                errors.Add(Errors.Expense.InvalidDescription);
            }

            if(errors.Count>0){
                 return errors;
            }

            return new Expense(
                id ?? Guid.NewGuid(),
                description,
                category,
                amount,
                date 
            );
        }

        public static ErrorOr<Expense> From(CreateExpenseRequest request){
            return Create(
                request.Description,
                request.Category,
                request.Amount,
                request.Date
            );
        }

        public static ErrorOr<Expense> From(Guid id, UpsertExpenseRequest request){
            return Create(
                request.Description,
                request.Category,
                request.Amount,
                request.Date,
                id
            );
        }
    }
}