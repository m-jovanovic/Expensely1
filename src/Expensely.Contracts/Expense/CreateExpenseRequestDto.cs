using System;

namespace Expensely.Contracts.Expense
{
    public class CreateExpenseRequestDto
    {
        public Guid UserId { get; set; }

        public decimal Amount { get; set; }

        public int CurrencyId { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
