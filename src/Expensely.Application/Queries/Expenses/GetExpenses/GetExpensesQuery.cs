using System.Collections.Generic;
using Expensely.Application.Models.Expense;
using MediatR;

namespace Expensely.Application.Queries.Expenses.GetExpenses
{
    public class GetExpensesQuery : IRequest<IEnumerable<ExpenseDto>>
    {
    }
}
