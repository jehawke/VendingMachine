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
            _testFoodDispenser.Restock();
            Assert.IsTrue(_testFoodDispenser.Dispense("Soda"));
        }

        [TestMethod]
        public void TestFoodDispenserCanDispenseChips()
        {
            _testFoodDispenser.Restock();
            Assert.IsTrue(_testFoodDispenser.Dispense("Chips"));
        }

        [TestMethod]
        public void TestFoodDispenserCanDispenseCandy()
        {
            _testFoodDispenser.Restock();
            Assert.IsTrue(_testFoodDispenser.Dispense("Candy"));
        }

        [TestMethod]
        public void TestFoodDispenserReturnsFalseWhenItHasNoItemToDispense()
        {
            _inventoryToTest = _testFoodDispenser.GetInventory();
            Assert.AreEqual(0,_inventoryToTest.Count);
            Assert.IsFalse(_testFoodDispenser.Dispense("Candy"));
        }

        [TestMethod]
        public void TestFoodDispenserReturnsFalseWhenPassedAnItemItWillNeverHaveInStock()
        {
            _testFoodDispenser.Restock();
            _inventoryToTest = _testFoodDispenser.GetInventory();
            Assert.AreEqual(3, _inventoryToTest.Count);
            Assert.IsFalse(_testFoodDispenser.Dispense("Steak"));
        }
    }
}
