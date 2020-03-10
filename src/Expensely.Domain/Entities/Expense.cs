using System;

namespace Expensely.Domain.Entities
{
    public class Expense : Entity, IAuditableEntity
    {
        private DateTime _occurredOnUtc;

        public Expense(Guid id, Guid userId, decimal amount, string currency, DateTime occurredOnUtc)
            : base(id.ToString())
        {
            UserId = userId;
            Amount = amount;
            Currency = currency;
            OccurredOnUtc = occurredOnUtc;
        }

        public Guid UserId { get; }

        public decimal Amount { get; }

        public string Currency { get; }

        public DateTime OccurredOnUtc
        {
            get => _occurredOnUtc.Date;
            private set => _occurredOnUtc = value;
        }

        public bool Cancelled { get; private set; }

        public DateTime CreatedOnUtc { get; private set; }

        public DateTime? ModifiedOnUtc { get; private set; }

        public void ChangeOccurrenceDate(DateTime occurrenceDate)
        {
            if (OccurredOnUtc == occurrenceDate)
            {
                return;
            }

            if (occurrenceDate.Kind != DateTimeKind.Utc)
            {
                occurrenceDate = occurrenceDate.ToUniversalTime();
            }

            OccurredOnUtc = occurrenceDate;
        }

        public void Cancel()
        {
            if (Cancelled)
            {
                // TODO: Throw?
                return;
            }

            Cancelled = true;
        }
    }
}
