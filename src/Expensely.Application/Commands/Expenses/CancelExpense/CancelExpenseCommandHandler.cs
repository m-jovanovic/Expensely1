using System.Threading;
using System.Threading.Tasks;
using Expensely.Domain;
using Expensely.Domain.Entities;
using MediatR;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Commands.Expenses.CancelExpense
{
    public sealed class CancelExpenseCommandHandler : IRequestHandler<CancelExpenseCommand, Result>
    {
        private readonly IAsyncDocumentSession _session;

        public CancelExpenseCommandHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<Result> Handle(CancelExpenseCommand request, CancellationToken cancellationToken)
        {
            Expense? expense = await _session.LoadAsync<Expense>(request.Id, cancellationToken);

            if (expense is null)
            {
                return Result.Fail($"The expense with id {request.Id} was not found.");
            }

            expense.Cancel();

            await _session.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}