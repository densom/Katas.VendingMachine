namespace Katas.VendingMachine
{
    public class Purchase
    {
        internal Purchase(Product product, decimal change)
        {
            Product = product;
            Change = change;
        }

        public Product Product { get; private set; }
        public decimal Change { get; private set; }
    }
}