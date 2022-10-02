using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using RestApi.Contracts.Expenses;
using RestApi.Models;
using RestApi.Services;

namespace RestApi.Controllers
{
    public class ExpensesController: ApiController{

        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService){
            _expenseService=expenseService;
        }
        
        [HttpPost]
        public IActionResult CreateExpense(CreateExpenseRequest request)
        {
            ErrorOr<Expense> requestToExpenseResult = Expense.From(request);

            if(requestToExpenseResult.IsError){
                return Problem(requestToExpenseResult.Errors);
            }
            var  expense =  requestToExpenseResult.Value;
            ErrorOr<Created> createExpenseResult = _expenseService.CreateExpense(expense);

            return createExpenseResult.Match(
                created => CreatedAtGetExpense(expense),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetExpense(Guid id){
            ErrorOr<Expense> getExpenseResult = _expenseService.GetExpense(id);

            return getExpenseResult.Match(
                expense  => Ok(MapExpenseResponse(expense)),
                errors => Problem(errors));

        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertExpense(Guid id,  UpsertExpenseRequest request){

            var requestToExpenseResult = Expense.From(id, request);

             if(requestToExpenseResult.IsError){
                return Problem(requestToExpenseResult.Errors);
            }
            var  expense =  requestToExpenseResult.Value;

            ErrorOr<UpsertedExpense> upsertedExpenseResult = _expenseService.UpsertExpense(expense);

            //TODO: return 201 if a new  expense was created
            return upsertedExpenseResult.Match(
                upserted => upserted.IsNewlyCreated ? CreatedAtGetExpense(expense) : NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteExpense(Guid id){
            ErrorOr<Deleted> deletedExpenseResult = _expenseService.DeleteExpense(id);

            return deletedExpenseResult.Match(
                deleted => NoContent(),
                errors =>Problem(errors)
            );
        }

        private static ExpenseResponse MapExpenseResponse(Expense expense){
            return new ExpenseResponse(
                expense.Id,
                expense.Description,
                expense.Category,
                expense.Amount,
                expense.Date
            );
        }
        private IActionResult CreatedAtGetExpense(Expense expense)
        {
            return CreatedAtAction(
                            nameof(GetExpense),
                            new { id = expense.Id },
                            MapExpenseResponse(expense));
        }
    }
}