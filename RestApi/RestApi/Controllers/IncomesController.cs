using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using RestApi.Contracts.Incomes;
using RestApi.Dtos;
using RestApi.Models;
using RestApi.Services;

namespace RestApi.Controllers
{
    public class IncomesController: ApiController{
        private readonly IIncomeService _incomeService;

        public IncomesController(IIncomeService incomeService){
            _incomeService=incomeService;
        }
        [HttpPost]
        public async Task<ActionResult<IncomeDto>>CreateItemAsync(CreateIncomeDto incomeDto){
            Income income = new (){
                Id=Guid.NewGuid(),
                Description=incomeDto.Description,
                Category=incomeDto.Category,
                Amount = incomeDto.Amount,
                Date = incomeDto.Date
            };
            await _incomeService.CreateItemAsync(income);
            return CreatedAtAction(nameof(GetItem), new{id=income.Id}, income.AsDto());
        }

        [HttpGet("{id:guid}")]
        public async Task< ActionResult<IncomeDto>> GetItem(Guid id){
            var income = await _incomeService.GetItemAsync(id);
            if(income is null) return NotFound();
            return Ok(income.AsDto());
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id,  UpdateIncomeDto incomeDto){
            var existingItem= await _incomeService.GetItemAsync(id);
            if(existingItem is null){
                return NotFound();
            }
            Income updatedIncome = existingItem  with {
                Description=incomeDto.Description,
                Category=incomeDto.Description,
                Amount=incomeDto.Amount,
                Date=incomeDto.Date
            };
            await _incomeService.UpdateItemAsync(updatedIncome);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id){
            var existingItem = await _incomeService.GetItemAsync(id);
            if(existingItem is null){
                return NotFound();
            }
            await _incomeService.DeleteItemAsync(id);
            return NoContent();

        }


        
        // [HttpPost]
        // public IActionResult CreateIncome(CreateIncomeRequest request)
        // {
        //     ErrorOr<Income> requestToIncomeResult = Income.From(request);

        //     if(requestToIncomeResult.IsError){
        //         return Problem(requestToIncomeResult.Errors);
        //     }
        //     var  income =  requestToIncomeResult.Value;
        //     ErrorOr<Created> createIncomeResult = _incomeService.CreateIncome(income);

        //     return createIncomeResult.Match(
        //         created => CreatedAtGetIncome(income),
        //         errors => Problem(errors)
        //     );
        // }

        // [HttpGet("{id:guid}")]
        // public IActionResult GetIncome(Guid id){
        //     ErrorOr<Income> getIncomeResult = _incomeService.GetIncome(id);

        //     return getIncomeResult.Match(
        //         income  => Ok(MapIncomeResponse(income)),
        //         errors => Problem(errors));

        // }

        // [HttpPut("{id:guid}")]
        // public IActionResult UpsertIncome(Guid id,  UpsertIncomeRequest request){

        //     var requestToIncomeResult = Income.From(id, request);

        //      if(requestToIncomeResult.IsError){
        //         return Problem(requestToIncomeResult.Errors);
        //     }
        //     var  income =  requestToIncomeResult.Value;

        //     ErrorOr<UpsertedIncome> upsertedIncomeResult = _incomeService.UpsertIncome(income);

        //     //TODO: return 201 if a new  expense was created
        //     return upsertedIncomeResult.Match(
        //         upserted => upserted.IsNewlyCreated ? CreatedAtGetIncome(income) : NoContent(),
        //         errors => Problem(errors)
        //     );
        // }

        // [HttpDelete("{id:guid}")]
        // public IActionResult DeleteIncome(Guid id){
        //     ErrorOr<Deleted> deletedIncomeResult = _incomeService.DeleteIncome(id);

        //     return deletedIncomeResult.Match(
        //         deleted => NoContent(),
        //         errors =>Problem(errors)
        //     );
        // }

        // private static IncomeResponse MapIncomeResponse(Income income){
        //     return new IncomeResponse(
        //         income.Id,
        //         income.Description,
        //         income.Category,
        //         income.Amount,
        //         income.Date
        //     );
        // }
        // private IActionResult CreatedAtGetIncome(Income income)
        // {
        //     return CreatedAtAction(
        //                     nameof(GetIncome),
        //                     new { id = income.Id },
        //                     MapIncomeResponse(income));
        // }
    }
}