namespace Katas.VendingMachine
{
    public class VendingMachine
    {
        Products _products = new Products();

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

        public void InsertCoin(params decimal[] coinAmounts)
        {
            foreach (var coinAmount in coinAmounts)
            {
                Amount += coinAmount;
            }
            
        }
    }
}