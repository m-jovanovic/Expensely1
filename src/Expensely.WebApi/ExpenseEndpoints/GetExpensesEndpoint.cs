using System.Collections.Generic;
using System.Threading.Tasks;
using Expensely.Application.Queries.Expenses.GetExpenses;
using Expensely.Domain.Entities;
using Expensely.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class GetExpensesEndpoint : AsyncEndpoint<Request, IEnumerable<Expense>>
    {
        private readonly IMediator _mediator;

        public GetExpensesEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("api/expenses")]
        public override async Task<ActionResult<IEnumerable<Expense>>> HandleAsync([FromQuery]Request request)
        {
            return Ok(await _mediator.Send(new GetExpensesQuery()));
        }
    }

    public class Request
    {
    }
}
