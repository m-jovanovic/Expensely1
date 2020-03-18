using System;

namespace Expensely.Contracts
{
    public class CreateExpenseRequestDto
    {
        public CreateExpenseRequestDto()
        {
            Currency = string.Empty;
        }

        public Guid UserId { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
