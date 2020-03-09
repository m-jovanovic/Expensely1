using System.Collections.Generic;
using System.Threading.Tasks;
using Expensely.Application.Models.Expense;
using Expensely.Application.Queries.Expenses.GetExpenses;
using Expensely.WebApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    [Route("api/expenses")]
    public class GetExpensesEndpoint : AsyncEndpoint<GetExpensesQuery, IEnumerable<ExpenseDto>>
    {
        private readonly IMediator _mediator;

        public GetExpensesEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<ExpenseDto>>> HandleAsync([FromQuery]GetExpensesQuery request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
