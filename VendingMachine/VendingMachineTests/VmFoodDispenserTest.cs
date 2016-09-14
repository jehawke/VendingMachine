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
            Assert.AreEqual(3,testFoodDispenser.Inventory.Count);
            Assert.AreEqual(5,testFoodDispenser.Inventory[0].Count);
            Assert.AreEqual(5, testFoodDispenser.Inventory[1].Count);
            Assert.AreEqual(5, testFoodDispenser.Inventory[2].Count);
        }

        [TestMethod]
        public void TestItemsAreRemovedFromInventoryWhenDispensed()
        {
            VmFoodDispenser testFoodDispenser = new VmFoodDispenser();
            testFoodDispenser.Restock();
            Assert.AreEqual(5, testFoodDispenser.Inventory[0].Count);
            testFoodDispenser.Dispense("Soda");
            Assert.AreEqual(4, testFoodDispenser.Inventory[0].Count);
        }

        [TestMethod]
        public void TestOtherItemsAreNotRemovedFromInventoryWhenDispensed()
        {
            VmFoodDispenser testFoodDispenser = new VmFoodDispenser();
            testFoodDispenser.Restock();
            Assert.AreEqual(5, testFoodDispenser.Inventory[0].Count);
            testFoodDispenser.Dispense("Soda");
            Assert.AreEqual(4, testFoodDispenser.Inventory[0].Count);
            Assert.AreEqual(5, testFoodDispenser.Inventory[1].Count);
            Assert.AreEqual(5, testFoodDispenser.Inventory[2].Count);
        }

        [TestMethod]
        public void TestFoodDispenserCanDispenseSoda()
        {
            VmFoodDispenser testFoodDispenser = new VmFoodDispenser();
            string itemToDispense = "Soda";
            string dispensedItem = testFoodDispenser.Dispense(itemToDispense);
            Assert.AreEqual("Soda", dispensedItem);
        }

        [TestMethod]
        public void TestFoodDispenserCanDispenseChips()
        {
            VmFoodDispenser testFoodDispenser = new VmFoodDispenser();
            string itemToDispense = "Chips";
            string dispensedItem = testFoodDispenser.Dispense(itemToDispense);
            Assert.AreEqual("Chips", dispensedItem);
        }

        [TestMethod]
        public void TestFoodDispenserCanDispenseCandy()
        {
            VmFoodDispenser testFoodDispenser = new VmFoodDispenser();
            string itemToDispense = "Candy";
            string dispensedItem = testFoodDispenser.Dispense(itemToDispense);
            Assert.AreEqual("Candy", dispensedItem);
        }
    }
}
