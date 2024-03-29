﻿using System;
using Expensely.Application.Interfaces;
using Expensely.Domain;

namespace Expensely.Application.Commands.Expenses.UpdateExpense
{
    public sealed class UpdateExpenseCommand : ICommand<Result>
    {
        public UpdateExpenseCommand(Guid expenseId, decimal amount, int currencyId, DateTime occurredOn)
        {
            ExpenseId = expenseId;
            Amount = amount;
            CurrencyId = currencyId;
            OccurredOn = occurredOn;
        }

        public Guid ExpenseId { get; }

        public decimal Amount { get; }

        public int CurrencyId { get; }

        public DateTime OccurredOn { get; }
    }
}
