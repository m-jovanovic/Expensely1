using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Expensely.Application.Extensions;
using Expensely.Contracts.Expense;
using MediatR;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Queries.Expenses.GetExpenses
{
    public class GetExpensesQueryHandler : IRequestHandler<GetExpensesQuery, IReadOnlyList<ExpenseDto>>
    {
        private readonly IAsyncDocumentSession _session;

        public GetExpensesQueryHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<IReadOnlyList<ExpenseDto>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
        {
            List<ExpenseDto> expenseDtos = await _session
                .Query<Domain.Entities.Expense>()
                .NoTracking()
                .Where(x => x.UserId == request.UserId && !x.Cancelled)
                .Select(x => new ExpenseDto
                {
                    Id = x.Id,
                    Amount = x.Money.Amount,
                    Currency = x.Money.Currency.Symbol,
                    OccurredOnUtc = x.OccurredOnUtc
                })
                .ToListAsync(cancellationToken);

            return expenseDtos;
        }
    }
}