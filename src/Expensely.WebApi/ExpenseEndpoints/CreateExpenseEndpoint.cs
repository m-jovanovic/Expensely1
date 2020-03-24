﻿using System.Threading.Tasks;
using Expensely.Application.Commands.Expense.CreateExpense;
using Expensely.Contracts;
using Expensely.Contracts.Expense;
using Expensely.WebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.ExpenseEndpoints
{
    public class CreateExpenseEndpoint : AsyncEndpoint<CreateExpenseRequestDto, bool>
    {
        [HttpPost("expenses")]
        public override async Task<ActionResult<bool>> HandleAsync([FromBody]CreateExpenseRequestDto request)
        {
            var command = new CreateExpenseCommand(request.UserId, request.Amount, request.CurrencyId, request.OccurredOn);

            return Ok(await Mediator.Send(command));
        }
    }
}
