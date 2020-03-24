using System;
using System.Threading;
using System.Threading.Tasks;
using Expensely.Domain.Entities;
using Expensely.Domain.ValueObjects;
using MediatR;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Commands.Expense.CreateExpense
{
    public sealed class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, bool>
    {
        private readonly IAsyncDocumentSession _session;

        public CreateExpenseCommandHandler(IAsyncDocumentSession session) => _session = session;

        public async Task<bool> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var currency = Currency.FromId(request.CurrencyId);

            if (currency is null)
            {
                return false;
            }

            var money = new Money(request.Amount, currency);

            var expense = new Domain.Entities.Expense(
                Guid.NewGuid(),
                request.UserId,
                money,
                request.OccurredOn.ToUniversalTime());

            await _session.StoreAsync(expense, cancellationToken);

            await _session.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
