using System;
using System.Threading;
using System.Threading.Tasks;
using Expensely.Domain;
using Expensely.Domain.Entities;
using Expensely.Domain.ValueObjects;
using MediatR;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Commands.Expenses.CreateExpense
{
    public sealed class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Result>
    {
        private readonly IAsyncDocumentSession _session;

        public CreateExpenseCommandHandler(IAsyncDocumentSession session) => _session = session;

        public async Task<Result> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var currency = Currency.FromId(request.CurrencyId);

            if (currency is null)
            {
                return Result.Fail($"The currency with id {request.CurrencyId} was not found.");
            }

            var money = new Money(request.Amount, currency);

            var expense = new Expense(
                Guid.NewGuid(),
                request.UserId,
                money,
                request.OccurredOn.ToUniversalTime());

            await _session.StoreAsync(expense, cancellationToken);

            await _session.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
