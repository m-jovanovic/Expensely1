using System;
using Expensely.Application.Models.Expenses;
using MediatR;

namespace Expensely.Application.Queries.Expenses.GetExpenseById
{
    public class GetExpenseByIdQuery : IRequest<ExpenseDto?>
    {
        public GetExpenseByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
