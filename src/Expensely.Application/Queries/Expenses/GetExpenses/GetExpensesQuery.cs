using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Expensely.Domain.Entities;
using MediatR;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Queries.Expenses.GetExpenses
{
    public class GetExpensesQuery : IRequest<IEnumerable<Expense>>
    {
    }

    public class GetExpensesQueryHandler : IRequestHandler<GetExpensesQuery, IEnumerable<Expense>>
    {
        private readonly IAsyncDocumentSession _session;

        public GetExpensesQueryHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<IEnumerable<Expense>> Handle(GetExpensesQuery request, CancellationToken cancellationToken)
        {
            return await _session.Query<Expense>().ToListAsync(cancellationToken);
        }
    }
}
