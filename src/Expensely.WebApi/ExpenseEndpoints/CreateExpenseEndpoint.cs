using System.Threading.Tasks;
using Expensely.Application.Commands.Expenses.CreateExpense;
using Expensely.Contracts;
using Expensely.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class CreateExpenseEndpoint : AsyncEndpoint<CreateExpenseRequestDto, bool>
    {
        [HttpPost("expenses")]
        public override async Task<ActionResult<bool>> HandleAsync([FromBody]CreateExpenseRequestDto request)
        {
            var command = new CreateExpenseCommand(request.UserId, request.Amount, request.Currency, request.OccurredOn);

            return Ok(await Mediator.Send(command));
        }
    }
}
