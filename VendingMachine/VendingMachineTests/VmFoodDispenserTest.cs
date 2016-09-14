using System;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmFoodDispenserTest
    {
        VmFoodDispenser _testFoodDispenser;

        [TestInitialize]
        public void Initialize()
        {
            _testFoodDispenser = new VmFoodDispenser();
        }

        [TestMethod]
        public void TestItemsAreAddedToInventoryWhenRestockIsCalled()
        {
            Assert.AreEqual(0,_testFoodDispenser.Inventory.Count);
            _testFoodDispenser.Restock();
            Assert.AreEqual(3,_testFoodDispenser.Inventory.Count);
            Assert.AreEqual(5,_testFoodDispenser.Inventory[0].Count);
            Assert.AreEqual(5, _testFoodDispenser.Inventory[1].Count);
            Assert.AreEqual(5, _testFoodDispenser.Inventory[2].Count);
        }

        [TestMethod]
        public void TestItemsAreRemovedFromInventoryWhenDispensed()
        {
            _testFoodDispenser.Restock();
            Assert.AreEqual(5, _testFoodDispenser.Inventory[0].Count);
            _testFoodDispenser.Dispense("Soda");
            Assert.AreEqual(4, _testFoodDispenser.Inventory[0].Count);
        }

        [TestMethod]
        public void TestOtherItemsAreNotRemovedFromInventoryWhenDispensed()
        {
            _testFoodDispenser.Restock();
            Assert.AreEqual(5, _testFoodDispenser.Inventory[0].Count);
            _testFoodDispenser.Dispense("Soda");
            Assert.AreEqual(4, _testFoodDispenser.Inventory[0].Count);
            Assert.AreEqual(5, _testFoodDispenser.Inventory[1].Count);
            Assert.AreEqual(5, _testFoodDispenser.Inventory[2].Count);
        }

        [TestMethod]
        public void TestFoodDispenserCanDispenseSoda()
        {
            string itemToDispense = "Soda";
            _testFoodDispenser.Restock();
            string dispensedItem = _testFoodDispenser.Dispense(itemToDispense);
            Assert.AreEqual("Soda", dispensedItem);
        }

        [TestMethod]
        public void TestFoodDispenserCanDispenseChips()
        {
            string itemToDispense = "Chips";
            _testFoodDispenser.Restock();
            string dispensedItem = _testFoodDispenser.Dispense(itemToDispense);
            Assert.AreEqual("Chips", dispensedItem);
        }

        [TestMethod]
        public void TestFoodDispenserCanDispenseCandy()
        {
            string itemToDispense = "Candy";
            _testFoodDispenser.Restock();
            string dispensedItem = _testFoodDispenser.Dispense(itemToDispense);
            Assert.AreEqual("Candy", dispensedItem);
        }

        [TestMethod]
        public void TestFoodDispenserReturnsNullWhenItHasNoItemToDispense()
        {
            Assert.AreEqual(0,_testFoodDispenser.Inventory.Count);
            string itemToDispense = "Candy";
            string dispensedItem = _testFoodDispenser.Dispense(itemToDispense);
            Assert.IsNull(dispensedItem);
        }

        [TestMethod]
        public void TestFoodDispenserReturnsNullWhenPassedAnItemItWillNeverHaveInStock()
        {
            _testFoodDispenser.Restock();
            Assert.AreEqual(3, _testFoodDispenser.Inventory.Count);
            string itemToDispense = "Steak";
            string dispensedItem = _testFoodDispenser.Dispense(itemToDispense);
            Assert.IsNull(dispensedItem);
        }
    }
}
