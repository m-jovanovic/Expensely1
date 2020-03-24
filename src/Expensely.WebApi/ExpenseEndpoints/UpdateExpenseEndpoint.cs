using System.Threading.Tasks;
using Expensely.Application.Commands.Expenses.UpdateExpense;
using Expensely.Contracts.Expense;
using Expensely.Domain;
using Expensely.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class UpdateExpenseEndpoint : AsyncEndpoint<UpdateExpenseRequestDto>
    {
        [HttpPut("expenses")]
        public override async Task<IActionResult> HandleAsync(UpdateExpenseRequestDto request)
        {
            var command = new UpdateExpenseCommand(request.ExpenseId, request.Amount, request.CurrencyId, request.OccurredOn);

            Result result = await Mediator.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }
    }
}
