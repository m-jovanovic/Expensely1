using System.Threading.Tasks;
using Expensely.Application.Models.Expense;
using Expensely.Application.Queries.Expenses.GetExpenseById;
using Expensely.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    [Route("api/expenses")]
    public class GetExpenseByIdEndpoint : AsyncEndpoint<string, ExpenseDto>
    {
        private readonly IMediator _mediator;

        public GetExpenseByIdEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<ExpenseDto>> HandleAsync(string id)
        {
            return Ok(await _mediator.Send(new GetExpenseByIdQuery(id)));
        }
    }
}
