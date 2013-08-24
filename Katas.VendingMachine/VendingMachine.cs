namespace Katas.VendingMachine
{
    public class VendingMachine
    {
        Products _products = new Products();
        private string _display = string.Empty;

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
            get { return _display; }
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
            var product = AvailableProducts[productDescription];

            if (product == null)
            {
                _display = "Make Another Selection";
                return new EmptyPurchase();
            }

            var change = Amount - product.Cost;
            Amount = 0;

            return new Purchase(product, change);
        }
    }
}