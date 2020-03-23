using System.Threading;
using System.Threading.Tasks;
using Expensely.Domain.Entities;
using Expensely.Domain.ValueObjects;
using MediatR;
using Raven.Client.Documents.Session;

namespace Expensely.Application.Commands.Expenses.UpdateExpense
{
    public sealed class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, bool>
    {
        private readonly IAsyncDocumentSession _session;

        public UpdateExpenseCommandHandler(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public async Task<bool> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            Expense? expense = await _session.LoadAsync<Expense>(request.ExpenseId.ToString(), cancellationToken);

            if (expense is null)
            {
                return false;
            }

            var currency = Currency.FromId(request.CurrencyId);

            if (currency is null)
            {
                return false;
            }

            var money = new Money(request.Amount, currency);

            expense.Update(money, request.OccurredOn.ToUniversalTime());

            await _session.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
