using Expensely.Application.Interfaces;
using Expensely.Domain;

namespace Expensely.Application.Commands.Expenses.CancelExpense
{
    public sealed class CancelExpenseCommand : ICommand<Result>
    {
        public CancelExpenseCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
