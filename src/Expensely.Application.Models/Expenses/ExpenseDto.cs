using System;

namespace Expensely.Application.Models.Expenses
{
    public class ExpenseDto
    {
        public ExpenseDto()
        {
            Id = string.Empty;
            Currency = string.Empty;
        }

        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public DateTime OccurredOnUtc { get; set; }
    }
}
