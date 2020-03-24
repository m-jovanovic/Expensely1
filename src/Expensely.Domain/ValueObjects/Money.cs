using System;
using System.Collections.Generic;

namespace Expensely.Domain.ValueObjects
{
    public sealed class Money : ValueObject, IComparable<Money>
    {
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; }

        public Currency Currency { get; }

        /// <inheritdoc />
        public int CompareTo(Money? other)
        {
            if (other is null)
            {
                return 1;
            }

            if (Currency != other.Currency)
            {
                // TODO: Throw custom exception.
            }

            return Amount.CompareTo(other.Amount);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Amount;
            yield return Currency;
        }
    }
}
