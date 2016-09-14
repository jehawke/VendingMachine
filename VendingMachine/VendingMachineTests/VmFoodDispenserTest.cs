using System;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmFoodDispenserTest
    {

        [TestMethod]
        public void TestItemsAreAddedToInventoryWhenRestockIsCalled()
        {
            VmFoodDispenser testFoodDispenser = new VmFoodDispenser();
            Assert.AreEqual(0,testFoodDispenser.Inventory.Count);
            testFoodDispenser.Restock();
            Assert.AreEqual(1,testFoodDispenser.Inventory.Count);
        }

        [TestMethod]
        public void TestItemsAreRemovedFromInventoryWhenDispensed()
        {
            VmFoodDispenser testFoodDispenser = new VmFoodDispenser();
            testFoodDispenser.Restock();
            Assert.AreEqual(1, testFoodDispenser.Inventory.Count);
            testFoodDispenser.Dispense("Soda");
            Assert.AreEqual(0, testFoodDispenser.Inventory.Count);
        }

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
