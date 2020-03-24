using System;
using Expensely.Application.Interfaces;
using Expensely.Contracts.Expense;

namespace Expensely.Application.Queries.Expense.GetExpenseById
{
    public class GetExpenseByIdQuery : IQuery<ExpenseDto?>
    {
        public GetExpenseByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
