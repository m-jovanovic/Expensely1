using Expensely.Application.Models.Expense;
using MediatR;

namespace Expensely.Application.Queries.Expenses.GetExpenseById
{
    public class GetExpenseByIdQuery : IRequest<ExpenseDto>
    {
        public GetExpenseByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
