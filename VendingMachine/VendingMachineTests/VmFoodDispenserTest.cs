using System;
using System.Collections.Generic;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmFoodDispenserTest
    {
        private VmFoodDispenser _testFoodDispenser;
        private List<List<string>> _inventoryToTest;

        [TestInitialize]
        public void Initialize()
        {
            _testFoodDispenser = new VmFoodDispenser();
            _inventoryToTest = new List<List<string>>();
        }

        [TestMethod]
        public void TestItemsAreAddedToInventoryWhenRestockIsCalled()
        {
            Assert.AreEqual(0, _inventoryToTest.Count);
            _testFoodDispenser.Restock();
            _inventoryToTest = _testFoodDispenser.GetInventory();
            Assert.AreEqual(3,_inventoryToTest.Count);
            Assert.AreEqual(5, _inventoryToTest[0].Count);
            Assert.AreEqual(5, _inventoryToTest[1].Count);
            Assert.AreEqual(5, _inventoryToTest[2].Count);
        }

        [TestMethod]
        public void TestItemsAreProperlyRemovedFromInventoryWhenDispensed()
        {
            _testFoodDispenser.Restock();
            _inventoryToTest = _testFoodDispenser.GetInventory();
            Assert.AreEqual(5, _inventoryToTest[0].Count);
            _testFoodDispenser.Dispense("Soda");
            Assert.AreEqual(4, _inventoryToTest[0].Count);
            Assert.AreEqual(5, _inventoryToTest[1].Count);
            Assert.AreEqual(5, _inventoryToTest[2].Count);
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
            _inventoryToTest = _testFoodDispenser.GetInventory();
            Assert.AreEqual(0,_inventoryToTest.Count);
            string itemToDispense = "Candy";
            string dispensedItem = _testFoodDispenser.Dispense(itemToDispense);
            Assert.IsNull(dispensedItem);
        }

        [TestMethod]
        public void TestFoodDispenserReturnsNullWhenPassedAnItemItWillNeverHaveInStock()
        {
            _testFoodDispenser.Restock();
            _inventoryToTest = _testFoodDispenser.GetInventory();
            Assert.AreEqual(3, _inventoryToTest.Count);
            string itemToDispense = "Steak";
            string dispensedItem = _testFoodDispenser.Dispense(itemToDispense);
            Assert.IsNull(dispensedItem);
        }
    }
}
