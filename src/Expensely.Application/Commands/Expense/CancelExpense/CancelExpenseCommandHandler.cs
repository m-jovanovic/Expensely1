using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Commands.Expense.CancelExpense
{
    public sealed class CancelExpenseCommandHandler : IRequestHandler<CancelExpenseCommand, bool>
    {
        private readonly IAsyncDocumentSession _session;

        public CancelExpenseCommandHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<bool> Handle(CancelExpenseCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Expense? expense = await _session.LoadAsync<Domain.Entities.Expense>(request.Id, cancellationToken);

            if (expense is null)
            {
                return false;
            }

            expense.Cancel();

            await _session.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}