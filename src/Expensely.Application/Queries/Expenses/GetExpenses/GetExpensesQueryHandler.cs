using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Expensely.Application.Extensions;
using Expensely.Application.Models.Expenses;
using Expensely.Domain.Entities;
using MediatR;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Queries.Expenses.GetExpenses
{
    public class GetExpensesQueryHandler : IRequestHandler<GetExpensesQuery, IEnumerable<ExpenseDto>>
    {
        private readonly IAsyncDocumentSession _session;

        public GetExpensesQueryHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<ExpenseDto>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
        {
            var expenses = await _session
                .Query<Expense>()
                .NoTracking()
                .Where(x => x.UserId == request.UserId && !x.Cancelled)
                .Select(x => new
                {
                    x.Id,
                    x.Amount,
                    x.Currency,
                    x.OccurredOnUtc
                })
                .ToListAsync(cancellationToken);

            IEnumerable<ExpenseDto> expenseDtos = expenses
                .Select(x => new ExpenseDto(x.Id, x.Amount, x.Currency, x.OccurredOnUtc));

            return expenseDtos;
        }
    }
}