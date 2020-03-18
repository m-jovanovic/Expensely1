using System.Threading.Tasks;
using Expensely.Application.Models.Expenses;
using Expensely.Application.Queries.Expenses.GetExpenseById;
using Expensely.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class GetExpenseByIdEndpoint : AsyncEndpoint<string, ExpenseDto>
    {
        [HttpGet("expenses/{id:guid}")]
        public override async Task<ActionResult<ExpenseDto>> HandleAsync(string id)
        {
            return Ok(await Mediator.Send(new GetExpenseByIdQuery(id)));
        }
    }
}
