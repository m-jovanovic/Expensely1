using System.Threading.Tasks;
using Expensely.Application.Commands.Expenses.CreateExpense;
using Expensely.Contracts.Expense;
using Expensely.Domain;
using Expensely.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class CreateExpenseEndpoint : AsyncEndpoint<CreateExpenseRequestDto>
    {
        [HttpPost("expenses")]
        public override async Task<IActionResult> HandleAsync([FromBody]CreateExpenseRequestDto request)
        {
            var command = new CreateExpenseCommand(request.UserId, request.Amount, request.CurrencyId, request.OccurredOn);

            Result result = await Mediator.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            // TODO: Return Created response.
            return NoContent();
        }
    }
}
