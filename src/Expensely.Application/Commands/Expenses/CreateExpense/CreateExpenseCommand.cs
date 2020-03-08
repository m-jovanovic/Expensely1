using System;
using Expensely.Application.Interfaces;

namespace Expensely.Application.Commands.Expenses.CreateExpense
{
    public class CreateExpenseCommand : ICommand<bool>
    {
        public CreateExpenseCommand() => Currency = string.Empty;

        public Guid UserId { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
