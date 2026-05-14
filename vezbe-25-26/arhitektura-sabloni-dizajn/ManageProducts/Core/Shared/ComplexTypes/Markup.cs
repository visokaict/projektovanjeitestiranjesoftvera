using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared.ComplexTypes
{
    public record Markup
    {
        public byte Percent { get; }
        public decimal Value => (decimal)Percent / 100;

        public static Markup Empty => new Markup(0); // Null Object Pattern

        public Markup(byte percent)
        {
            if (percent > 100) throw new ArgumentOutOfRangeException(nameof(percent));
            Percent = percent;
        }

        public override string ToString() => $"Markup percent: {Percent}";
    }
}
