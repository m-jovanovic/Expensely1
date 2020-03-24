using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Expensely.Application.Queries.Expenses.GetExpenses;
using Expensely.Contracts.Expense;
using Expensely.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class GetExpensesEndpoint : AsyncEndpoint<Guid, IReadOnlyList<ExpenseDto>>
    {
        [HttpGet("expenses")]
        public override async Task<ActionResult<IReadOnlyList<ExpenseDto>>> HandleAsync(Guid userId)
        {
            IReadOnlyList<ExpenseDto> readOnlyList = await Mediator.Send(new GetExpensesQuery(userId));

            return Ok(readOnlyList);
        }
    }
}
