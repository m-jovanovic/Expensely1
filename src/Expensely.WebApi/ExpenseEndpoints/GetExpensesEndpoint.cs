using System.Collections.Generic;
using System.Threading.Tasks;
using Expensely.Application.Models.Expenses;
using Expensely.Application.Queries.Expenses.GetExpenses;
using Expensely.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class GetExpensesEndpoint : AsyncEndpoint<string, IEnumerable<ExpenseDto>>
    {
        [HttpGet("expenses")]
        public override async Task<ActionResult<IEnumerable<ExpenseDto>>> HandleAsync(string userId)
        {
            return Ok(await Mediator.Send(new GetExpensesQuery(userId)));
        }
    }
}
