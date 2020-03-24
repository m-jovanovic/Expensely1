using System.Threading;
using System.Threading.Tasks;
using Expensely.Contracts.Expense;
using MediatR;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Queries.Expense.GetExpenseById
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseDto?>
    {
        private readonly IAsyncDocumentSession _session;

        public GetExpenseByIdQueryHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<ExpenseDto?> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Expense? expense = await _session.LoadAsync<Domain.Entities.Expense>(request.Id.ToString(), cancellationToken);

            if (expense is null)
            {
                return null;
            }

            var expenseDto = new ExpenseDto
            {
                Id = expense.Id,
                Amount = expense.Money.Amount,
                Currency = expense.Money.Currency.Symbol,
                OccurredOnUtc = expense.OccurredOnUtc
            };

            return expenseDto;
        }
    }
}