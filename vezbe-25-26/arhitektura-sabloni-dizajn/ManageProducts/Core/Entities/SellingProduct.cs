using Core.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class SellingProduct : Product
    {
        public Price SellingPrice { get; private set; } = Price.DefaultPrice;


        public SellingProduct(Product p, Markup markup) : base(p)
        {
            SellingPrice = p.Price + (p.Price * markup); // Initial selling price is the same as the cost price
        }

        public override string ToString()
        {
            return $"Id: {Id} Product: {Name}, Price: {Price:C}, Selling Price: {SellingPrice:C}, Quantity: {Quantity}, Available: {Available}";
        }
    }
}
