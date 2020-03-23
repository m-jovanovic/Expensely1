using System;
using System.Collections.Generic;
using System.Text;

namespace Expensely.Contracts
{
    public class UpdateExpenseRequestDto
    {
        public Guid ExpenseId { get; set; }

        public decimal Amount { get; set; }

        public int CurrencyId { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
