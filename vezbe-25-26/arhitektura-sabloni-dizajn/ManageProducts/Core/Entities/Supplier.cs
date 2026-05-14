using Core.Interfaces;
using Core.Shared.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Supplier : IEntity
    {
        private HashSet<SellingProduct> _sellingProducts = [];
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;
        public IReadOnlyCollection<SellingProduct> Products => _sellingProducts.AsReadOnly();
        public Markup Markup { get; private set; } = Markup.Empty;

        public static Supplier Empty => new Supplier(); // Null Object Pattern

        private Supplier()
        {

        }

        public Supplier(string name, byte percent = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty or whitespace.", nameof(name));
            Name = name;
            if (percent > 100)
                throw new ArgumentOutOfRangeException(nameof(percent), "Percent must be between 0 and 100.");
            Markup = new Markup(percent);
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            var newSellingProduct = new SellingProduct(product, Markup);
            _sellingProducts.Add(newSellingProduct);
        }

        public void RemoveProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            var sellingProductToBeRemoved = _sellingProducts.SingleOrDefault(sp => sp.Id == product.Id);
            if(sellingProductToBeRemoved == null)
                throw new InvalidOperationException("Product not found.");
            _sellingProducts.Remove(sellingProductToBeRemoved);
        }

        public override string ToString()
        {
            var sellingProductsInfo = string.Join(Environment.NewLine, Products);
            //or usage of StringBuilder

            return $"Id: {Id} Supplier: {Name}, Percent: {Markup.Value}%, Products Count: {Products.Count}{Environment.NewLine}Selling Products:{Environment.NewLine}{sellingProductsInfo}";
        }
    }
}
