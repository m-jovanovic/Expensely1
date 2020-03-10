using System.Threading;
using System.Threading.Tasks;
using Expensely.Domain.Entities;
using MediatR;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Commands.Expenses.CancelExpense
{
    public class CancelExpenseCommandHandler : IRequestHandler<CancelExpenseCommand, bool>
    {
        private readonly IAsyncDocumentSession _session;

        public CancelExpenseCommandHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<bool> Handle(CancelExpenseCommand request, CancellationToken cancellationToken)
        {
            Expense expense = await _session.LoadAsync<Expense>(request.Id, cancellationToken);

            expense.Cancel();

            await _session.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}