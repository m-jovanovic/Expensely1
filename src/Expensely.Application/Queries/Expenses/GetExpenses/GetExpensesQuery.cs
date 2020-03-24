using System;
using System.Collections.Generic;
using Expensely.Application.Interfaces;
using Expensely.Contracts.Expense;

namespace Expensely.Application.Queries.Expenses.GetExpenses
{
    public class GetExpensesQuery : IQuery<IReadOnlyList<ExpenseDto>>
    {
        public GetExpensesQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
