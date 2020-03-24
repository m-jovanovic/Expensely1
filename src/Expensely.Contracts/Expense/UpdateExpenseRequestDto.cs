using System;

namespace Expensely.Contracts.Expense
{
    public class UpdateExpenseRequestDto
    {
        public Guid ExpenseId { get; set; }

        public decimal Amount { get; set; }

        public int CurrencyId { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
