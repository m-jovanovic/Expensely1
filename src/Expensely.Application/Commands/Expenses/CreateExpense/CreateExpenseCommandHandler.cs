using System;
using System.Threading;
using System.Threading.Tasks;
using Expensely.Domain.Entities;
using MediatR;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Commands.Expenses.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, bool>
    {
        private readonly IAsyncDocumentSession _session;

        public CreateExpenseCommandHandler(IAsyncDocumentSession session) => _session = session;

        public async Task<bool> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense(
                Guid.NewGuid(),
                request.UserId,
                request.Amount,
                request.Currency,
                request.OccurredOn);

            await _session.StoreAsync(expense, cancellationToken);

            await _session.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
