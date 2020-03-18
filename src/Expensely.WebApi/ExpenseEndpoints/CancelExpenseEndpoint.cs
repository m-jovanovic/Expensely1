using System.Threading.Tasks;
using Expensely.Application.Commands.Expenses.CancelExpense;
using Expensely.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class CancelExpenseEndpoint : AsyncEndpoint<string, bool>
    {
        [HttpPost("expenses/cancel/{id}")]
        public override async Task<ActionResult<bool>> HandleAsync(string id)
        {
            return Ok(await Mediator.Send(new CancelExpenseCommand(id)));
        }
    }
}
