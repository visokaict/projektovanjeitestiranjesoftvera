using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared.ComplexTypes
{
    public record Currency
    {
        public string Code { get; }

        public string Name { get; }

        public string Symbol { get; }

        public static Currency Default => new("EUR", "Euro", "€");

        public Currency(string code, string name, string symbol)
        {
            Code = code;
            Name = name;
            Symbol = symbol;
        }

        public override string ToString() => Symbol;
    }
}
