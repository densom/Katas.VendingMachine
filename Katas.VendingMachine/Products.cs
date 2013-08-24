using System.Collections.Generic;

namespace Katas.VendingMachine
{
    public class Products
    {
        private readonly Dictionary<string, Product> _products = new Dictionary<string, Product>();

        public Product this[string description]
        {
            get
            {
                return GetProduct(description);
            }
        }

        private Product GetProduct(string description)
        {
            if (!_products.ContainsKey(description))
            {
                return null;
            }

            return _products[description];
        }

        internal void Add(Product product)
        {
            _products.Add(product.Description, product);
        }
    }
}