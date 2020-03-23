﻿using System;
using System.Collections.Generic;
using Expensely.Application.Models.Expenses;
using MediatR;

namespace Expensely.Application.Queries.Expenses.GetExpenses
{
    public class GetExpensesQuery : IRequest<IReadOnlyList<ExpenseDto>>
    {
        public GetExpensesQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
