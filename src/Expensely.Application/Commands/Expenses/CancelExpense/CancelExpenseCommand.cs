﻿using Expensely.Application.Interfaces;

namespace Expensely.Application.Commands.Expenses.CancelExpense
{
    public class CancelExpenseCommand : ICommand<bool>
    {
        public CancelExpenseCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
