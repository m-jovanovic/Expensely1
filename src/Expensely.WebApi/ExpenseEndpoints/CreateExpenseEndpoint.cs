using System.Threading.Tasks;
using Expensely.Application.Commands.Expenses.CreateExpense;
using Expensely.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class CreateExpenseEndpoint : AsyncEndpoint<CreateExpenseCommand, bool>
    {
        private readonly IMediator _mediator;

        public CreateExpenseEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("api/expenses")]
        public override async Task<ActionResult<bool>> HandleAsync([FromBody]CreateExpenseCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
