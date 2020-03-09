using System;

namespace Expensely.Application.Models.Expense
{
    public class ExpenseDto
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public DateTime OccurredOnUtc { get; set; }
    }
}
