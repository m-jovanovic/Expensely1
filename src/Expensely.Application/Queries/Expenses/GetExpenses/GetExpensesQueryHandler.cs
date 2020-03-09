using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Expensely.Application.Models.Expense;
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
            List<ExpenseDto> expenseDtos = await _session
                .Query<Expense>()
                .Select(x => new ExpenseDto
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    Currency = x.Currency,
                    OccurredOnUtc = x.OccurredOnUtc
                })
                .ToListAsync(cancellationToken);

            return expenseDtos;
        }
    }
}