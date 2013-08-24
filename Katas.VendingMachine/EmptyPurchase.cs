namespace Katas.VendingMachine
{
    public class EmptyPurchase : Purchase
    {
        public EmptyPurchase()
            : base(null, 0m)
        {
        }
    }
}