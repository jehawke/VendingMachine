using System;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmFoodDispenserTest
    {
        [TestMethod]
        public void TestFoodDispenserCanDispenseSoda()
        {
            VmFoodDispenser testFoodDispenser = new VmFoodDispenser();
            string itemToDispense = "Soda";
            string dispensedItem = testFoodDispenser.Dispense(itemToDispense);
            Assert.AreEqual("Soda", dispensedItem);
        }
    }
}
