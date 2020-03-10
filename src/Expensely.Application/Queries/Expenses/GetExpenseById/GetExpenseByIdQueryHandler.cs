using System.Threading;
using System.Threading.Tasks;
using Expensely.Application.Models.Expenses;
using Expensely.Domain.Entities;
using MediatR;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Queries.Expenses.GetExpenseById
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseDto>
    {
        private readonly IAsyncDocumentSession _session;

        public GetExpenseByIdQueryHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<ExpenseDto> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            Expense expense = await _session.LoadAsync<Expense>(request.Id, cancellationToken);

            ExpenseDto expenseDto = expense;

            return expenseDto;
        }
    }
}