namespace Katas.VendingMachine
{
    public class Product
    {
        public string Description { get; private set; }
        public decimal Cost { get; private set; }

        public Product(string description, decimal cost)
        {
            Description = description;
            Cost = cost;
        }
    }
}