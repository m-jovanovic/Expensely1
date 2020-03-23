using System;
using System.Threading.Tasks;
using Expensely.Application.Models.Expenses;
using Expensely.Application.Queries.Expenses.GetExpenseById;
using Expensely.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class GetExpenseByIdEndpoint : AsyncEndpoint<Guid, ExpenseDto?>
    {
        [HttpGet("expenses/{id:guid}")]
        public override async Task<ActionResult<ExpenseDto?>> HandleAsync(Guid id)
        {
            ExpenseDto? expenseDto = await Mediator.Send(new GetExpenseByIdQuery(id));

            if (expenseDto is null)
            {
                return NotFound();
            }

            return Ok(expenseDto);
        }
    }
}
