using Expensely.Application.Interfaces;

namespace Expensely.Application.Commands.Expense.CancelExpense
{
    public sealed class CancelExpenseCommand : ICommand<bool>
    {
        public CancelExpenseCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
