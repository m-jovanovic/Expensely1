using System.Collections.Generic;
using System.Linq;

namespace Expensely.Domain.Entities
{
    public sealed class Currency : ValueObject
    {
        public static readonly Currency Usd = new Currency(1, "$");

        public static readonly Currency Eur = new Currency(2, "€");

        public static readonly Currency Rsd = new Currency(3, "din.");

        private static readonly IReadOnlyList<Currency> AllCurrencies = new List<Currency>
        {
            Usd,
            Eur,
            Rsd
        };

        private Currency(int id, string symbol)
            : this()
        {
            Symbol = symbol;
            Id = id;
        }

        private Currency()
        {
            Symbol = string.Empty;
        }

        public int Id { get; private set; }

        public string Symbol { get; private set; }

        public static Currency? FromId(int currencyId)
        {
            return AllCurrencies.SingleOrDefault(x => x.Id == currencyId);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Symbol;
        }
    }
}
