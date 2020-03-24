using System;
using Expensely.Application.Interfaces;

namespace Expensely.Application.Commands.Expenses.CreateExpense
{
    public sealed class CreateExpenseCommand : ICommand<bool>
    {
        public CreateExpenseCommand(Guid userId, decimal amount, int currencyId, DateTime occurredOn)
        {
            UserId = userId;
            Amount = amount;
            CurrencyId = currencyId;
            OccurredOn = occurredOn;
        }

        public Guid UserId { get; }

        public decimal Amount { get; }

        public int CurrencyId { get; }

        public DateTime OccurredOn { get; }
    }
}
