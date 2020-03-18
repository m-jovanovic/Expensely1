using System;
using Expensely.Application.Interfaces;

namespace Expensely.Application.Commands.Expenses.CreateExpense
{
    public class CreateExpenseCommand : ICommand<bool>
    {
        public CreateExpenseCommand(Guid userId, decimal amount, string currency, DateTime occurredOn)
        {
            UserId = userId;
            Amount = amount;
            Currency = currency;
            OccurredOn = occurredOn;
        }

        public Guid UserId { get; }

        public decimal Amount { get; }

        public string Currency { get; }

        public DateTime OccurredOn { get; }
    }
}
