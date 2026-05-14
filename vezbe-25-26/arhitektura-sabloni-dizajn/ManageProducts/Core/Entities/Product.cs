using Core.Interfaces;
using Core.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    public class Product : IEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        [MinLength(5)]
        public string Name { get; private set; } = string.Empty;
        public uint Quantity { get; private set; } = 0; //or byte, ushort, uint, ulong
        public bool Available => Quantity > 0;
        public Price Price { get; private set; } = Price.DefaultPrice;
        
        //public decimal SellingPrice { get; private set; } = 0m;
        public static Product Empty => new Product();//null object pattern

        protected Product()
        {

        }

        public Product(string name, Price price, uint quantity = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty or whitespace.", nameof(name));
            Name = name;
            if (price == null)
                throw new ArgumentNullException(nameof(price), "Price cannot be null.");
            Price = price;

            Quantity = quantity;
        }

        public Product(Product p)
        {
            Name = p.Name;
            Quantity = p.Quantity;
            Price = p.Price;
        }

        public override string ToString()
        {
            return $"Id: {Id} Product: {Name}, Price: {Price:C}, Quantity: {Quantity}, Available: {Available}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id,Name);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Product other)
            {
                return Id == other.Id && Name == other.Name;
            }
            return false;
        }
    }
}
