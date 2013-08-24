using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Katas.VendingMachine.Tests
{
    [TestFixture]
    public class VendingMachineTests
    {
        [Test]
        public void InitialState_NoMoneyInserted()
        {
            var vm = new VendingMachine();
            
            Assert.That(vm.Amount, Is.EqualTo(0.00M));
        }

        [Test]
        [TestCase(new[] {.25}, Result=.25)]
        [TestCase(new[] {.25, .25}, Result=.50)]
        public decimal InsertingCoins_IncreasesAmountToSumOfCoinsInserted(double[] coins)
        {
            var vm = new VendingMachine();

            foreach (var coin in coins)
            {
                vm.InsertCoin(Convert.ToDecimal(coin));
            }

            return vm.Amount;
        }

        [Test]
        public void InitializeWithProducts()
        {
            var product = new Product("Gum", .50m);
            var vm = new VendingMachine(product);

            Assert.That(vm.AvailableProducts["Gum"].Cost, Is.EqualTo(.50m));
        }

        [Test]
        public void InsertingExactAmountAndSelectingGum_SetsAmountBackToZero()
        {
            var product = new Product("Gum", .50m);
            var vm = new VendingMachine(product);

            vm.InsertCoin(.25m, .25m);

            vm.SelectProduct("Gum");

            Assert.That(vm.Amount, Is.EqualTo(0));

        }

        [Test]
        public void SelectingProduct_WithChange()
        {
            const string productDescription = "Chips";

            var product = new Product(productDescription, .40m);
            var vm = new VendingMachine(product);

            vm.InsertCoin(.25m, .25m);

            var purchase = vm.SelectProduct(productDescription);

            Assert.That(purchase.Product.Description, Is.EqualTo(productDescription));
            Assert.That(purchase.Change, Is.EqualTo(.10m));
            Assert.That(vm.Amount, Is.EqualTo(0));

        }

        [Test]
        public void SelectingProduct_OutOfStock()
        {
            var product = new Product("Chips", .40m);
            var vm = new VendingMachine(product);

            vm.InsertCoin(.25m, .25m);

            var purchase = vm.SelectProduct("Gum");

            Assert.That(purchase.Change, Is.EqualTo(0));
            Assert.That(purchase.Product, Is.EqualTo(null));
            Assert.That(vm.Display, Is.EqualTo("Make Another Selection"));

        }

        [Test]
        public void SelectingProduct_WithoutEnoughCredit()
        {
            var product = new Product("Nuts", .85m);
            var vm = new VendingMachine(product);

            vm.InsertCoin(.25m, .25m, .25m);

            var purchase = vm.SelectProduct("Nuts");

            Assert.That(purchase.Product, Is.EqualTo(null));
            Assert.That(purchase.Change, Is.EqualTo(0));
            Assert.That(vm.Amount, Is.EqualTo(.75m));
            Assert.That(vm.Display, Is.EqualTo("Deposit Additional 0.10"));

        }
       
    }
}