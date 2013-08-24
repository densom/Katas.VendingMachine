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
            

        }

        
    }
}