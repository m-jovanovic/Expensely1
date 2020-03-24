using System.Threading.Tasks;
using Expensely.Application.Commands.Expense.UpdateExpense;
using Expensely.Contracts;
using Expensely.Contracts.Expense;
using Expensely.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class UpdateExpenseEndpoint : AsyncEndpoint<UpdateExpenseRequestDto, bool>
    {
        [HttpPut("expenses")]
        public override async Task<ActionResult<bool>> HandleAsync(UpdateExpenseRequestDto request)
        {
            var command = new UpdateExpenseCommand(request.ExpenseId, request.Amount, request.CurrencyId, request.OccurredOn);

            return Ok(await Mediator.Send(command));
        }
    }
}
