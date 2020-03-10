using System;
using Expensely.Domain.Entities;

namespace Expensely.Application.Models.Expenses
{
    public class ExpenseDto
    {
        public ExpenseDto(string id, decimal amount, string currency, DateTime occurredOnUtc)
        {
            Id = id;
            Amount = amount;
            Currency = currency;
            OccurredOnUtc = occurredOnUtc;
        }

        public string Id { get; }

        public decimal Amount { get; }

        public string Currency { get; }

        public DateTime OccurredOnUtc { get; }

        public static implicit operator ExpenseDto(Expense expense)
            => new ExpenseDto(expense.Id, expense.Amount, expense.Currency, expense.OccurredOnUtc);
    }
}
