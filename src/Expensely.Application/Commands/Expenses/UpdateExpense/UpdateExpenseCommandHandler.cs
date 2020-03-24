using System.Threading;
using System.Threading.Tasks;
using Expensely.Domain;
using Expensely.Domain.Entities;
using Expensely.Domain.ValueObjects;
using MediatR;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Commands.Expenses.UpdateExpense
{
    public sealed class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Result>
    {
        private readonly IAsyncDocumentSession _session;

        public UpdateExpenseCommandHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<Result> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            Expense? expense = await _session.LoadAsync<Expense>(request.ExpenseId.ToString(), cancellationToken);

            if (expense is null)
            {
                return Result.Fail($"The expense with id {request.ExpenseId} was not found.");
            }

            var currency = Currency.FromId(request.CurrencyId);

            if (currency is null)
            {
                return Result.Fail($"The currency with id {request.CurrencyId} was not found.");
            }

            var money = new Money(request.Amount, currency);

            expense.Update(money, request.OccurredOn.ToUniversalTime());

            await _session.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
