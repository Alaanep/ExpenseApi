using Microsoft.AspNetCore.Mvc;
using RestApi.Dtos;
using RestApi.Models;
using RestApi.Services;

namespace RestApi.Controllers
{   
    [Route("Expenses")]
    public class ExpensesController: ApiController{

        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService){
            _expenseService=expenseService;
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseDto>>CreateItemAsync(CreateExpenseDto expenseDto){
            Expense expense = new (){
                Id=Guid.NewGuid(),
                Description=expenseDto.Category,
                Category=expenseDto.Category,
                Amount = expenseDto.Amount,
                Date = expenseDto.Date
            };
            await _expenseService.CreateItemAsync(expense);
            return CreatedAtAction(nameof(GetItem), new{id=expense.Id}, expense.AsDto());
        }

        [HttpGet("{id:guid}")]
        public async Task< ActionResult<ExpenseDto>> GetItem(Guid id){
            var expense = await _expenseService.GetItemAsync(id);
            if(expense is null) return NotFound();
            return Ok(expense.AsDto());
        }

        [HttpGet]
        public async Task<ActionResult<ExpenseDto>>GetItemsAsync(){
            var expenses = (await _expenseService.GetItemsAsync()).Select(expense=>expense.AsDto());
            return Ok(expenses);
            
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id,UpdateExpenseDto expenseDto){
            var existingItem= await _expenseService.GetItemAsync(id);
            if(existingItem is null){
                return NotFound();
            }
            Expense updatedExpense= existingItem with {
                Description=expenseDto.Description,
                Category=expenseDto.Description,
                Amount=expenseDto.Amount,
                Date=expenseDto.Date
            };
            await _expenseService.UpdateItemAsync(updatedExpense);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id){
            var existingItem = await _expenseService.GetItemAsync(id);
            if(existingItem is null){
                return NotFound();
            }
            await _expenseService.DeleteItemAsync(id);
            return NoContent();

        }

        
        // [HttpPost]
        // public IActionResult CreateExpense(CreateExpenseRequest request)
        // {
        //     ErrorOr<Expense> requestToExpenseResult = Expense.From(request);

        //     if(requestToExpenseResult.IsError){
        //         return Problem(requestToExpenseResult.Errors);
        //     }
        //     var  expense =  requestToExpenseResult.Value;
        //     ErrorOr<Created> createExpenseResult = _expenseService.CreateExpense(expense);

        //     return createExpenseResult.Match(
        //         created => CreatedAtGetExpense(expense),
        //         errors => Problem(errors)
        //     );
        // }

        // [HttpGet("{id:guid}")]
        // public IActionResult GetExpense(Guid id){
        //     ErrorOr<Expense> getExpenseResult = _expenseService.GetExpense(id);

        //     return getExpenseResult.Match(
        //         expense  => Ok(MapExpenseResponse(expense)),
        //         errors => Problem(errors));

        // }

        // [HttpPut("{id:guid}")]
        // public IActionResult UpsertExpense(Guid id,  UpsertExpenseRequest request){

        //     var requestToExpenseResult = Expense.From(id, request);

        //      if(requestToExpenseResult.IsError){
        //         return Problem(requestToExpenseResult.Errors);
        //     }
        //     var  expense =  requestToExpenseResult.Value;

        //     ErrorOr<UpsertedExpense> upsertedExpenseResult = _expenseService.UpsertExpense(expense);

        //     //TODO: return 201 if a new  expense was created
        //     return upsertedExpenseResult.Match(
        //         upserted => upserted.IsNewlyCreated ? CreatedAtGetExpense(expense) : NoContent(),
        //         errors => Problem(errors)
        //     );
        // }

        // [HttpDelete("{id:guid}")]
        // public IActionResult DeleteExpense(Guid id){
        //     ErrorOr<Deleted> deletedExpenseResult = _expenseService.DeleteExpense(id);

        //     return deletedExpenseResult.Match(
        //         deleted => NoContent(),
        //         errors =>Problem(errors)
        //     );
        // }

        // private static ExpenseResponse MapExpenseResponse(Expense expense){
        //     return new ExpenseResponse(
        //         expense.Id,
        //         expense.Description,
        //         expense.Category,
        //         expense.Amount,
        //         expense.Date
        //     );
        // }
        // private IActionResult CreatedAtGetExpense(Expense expense)
        // {
        //     return CreatedAtAction(
        //                     nameof(GetExpense),
        //                     new { id = expense.Id },
        //                     MapExpenseResponse(expense));
        // }
    }
}