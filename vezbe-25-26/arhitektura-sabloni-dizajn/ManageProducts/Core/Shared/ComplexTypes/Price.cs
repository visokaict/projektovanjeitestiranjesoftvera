using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared.ComplexTypes
{
    public class Price
    {
        public decimal Value { get; }
        public Currency Currency { get; }

        public static Price DefaultPrice => new Price(0, Currency.Default);

        public Price(decimal value, Currency currency)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
            Value = value;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public static Price operator +(Price first, Price second)
        {
            if (!first.Currency.Equals(second.Currency))
                throw new InvalidOperationException("Currencies are different");

            return new Price(first.Value + second.Value, first.Currency);
        }

        public static Price operator *(Price price, Markup markup)
        {
            return new Price(price.Value * markup.Value, price.Currency);
        }



        public override string ToString() => $"Price {Value} {Currency}";
    }
}
