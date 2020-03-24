using System;
using Expensely.Domain.Exceptions;
using Expensely.Domain.ValueObjects;

namespace Expensely.Domain.Entities
{
    public class Expense : Entity, IAuditableEntity
    {
        private DateTime _occurredOnUtc;

        public Expense(Guid id, Guid userId, Money money, DateTime occurredOnUtc)
            : base(id.ToString())
        {
            UserId = userId;
            Money = money;
            OccurredOnUtc = occurredOnUtc;
        }

        public Guid UserId { get; }

        public Money Money { get; private set; }

        public DateTime OccurredOnUtc
        {
            get => _occurredOnUtc.Date;
            private set => _occurredOnUtc = value;
        }

        public bool Cancelled { get; private set; }

        public DateTime CreatedOnUtc { get; private set; }

        public DateTime? ModifiedOnUtc { get; private set; }

        public void Update(Money money, DateTime occurredOnUtc)
        {
            Money = money;

            OccurredOnUtc = occurredOnUtc;
        }

        public void Cancel()
        {
            if (Cancelled)
            {
                throw new DomainException("The expense has already been cancelled.");
            }

            Cancelled = true;
        }
    }
}
