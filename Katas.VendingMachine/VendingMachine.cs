namespace Katas.VendingMachine
{
    public class VendingMachine
    {
        readonly Products _products = new Products();

        public VendingMachine(Product product)
        {
            _products.Add(product);
        }

        public VendingMachine()
        {

        }

        public decimal Amount { get; private set; }

        public Products AvailableProducts
        {
            get { return _products; }
        }

        public string Display
        {
            get;
            private set;
        }

        public void InsertCoin(params decimal[] coinAmounts)
        {
            foreach (var coinAmount in coinAmounts)
            {
                Amount += coinAmount;
            }

        }

        public Purchase SelectProduct(string productDescription)
        {
            if (!IsProductFound(productDescription))
            {
                Display = "Make Another Selection";
                return new EmptyPurchase();
            }

            var product = AvailableProducts[productDescription];

            if (product.Cost > Amount)
            {
                Display = string.Format("Deposit Additional {0}", product.Cost - Amount);
                return new EmptyPurchase();
            }

            var change = CalculateChange(product);
            
            ResetAmount();

            return new Purchase(product, change);
        }

        private void ResetAmount()
        {
            Amount = 0;
        }

        private bool IsProductFound(string productDescription)
        {
            var product = AvailableProducts[productDescription];
            return product != null;
        }

        private decimal CalculateChange(Product product)
        {
            return Amount - product.Cost;
        }
    }
}