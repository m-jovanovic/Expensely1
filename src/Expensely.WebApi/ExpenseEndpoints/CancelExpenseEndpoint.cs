using System.Threading.Tasks;
using Expensely.Application.Commands.Expenses.CancelExpense;
using Expensely.Domain;
using Expensely.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class CancelExpenseEndpoint : AsyncEndpoint<string>
    {
        [HttpPost("expenses/cancel/{id}")]
        public override async Task<IActionResult> HandleAsync(string id)
        {
            Result result = await Mediator.Send(new CancelExpenseCommand(id));

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }
    }
}
