using System.Threading.Tasks;
using Expensely.Application.Commands.Expenses.CancelExpense;
using Expensely.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    [Route("api/expenses")]
    public class CancelExpenseEndpoint : AsyncEndpoint<string, bool>
    {
        private readonly IMediator _mediator;

        public CancelExpenseEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id}")]
        public override async Task<ActionResult<bool>> HandleAsync(string id)
        {
            return Ok(await _mediator.Send(new CancelExpenseCommand(id)));
        }
    }
}
