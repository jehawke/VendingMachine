using System.Collections.Generic;
using VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VendingMachineTests
{
    [TestClass]
    public class VmFoodSlotTest
    {
        private VmFoodSlot _foodSlot;

        [TestInitialize]
        public void Initialize()
        {
            _foodSlot = new VmFoodSlot();
        }

        [TestMethod]
        public void TestGetItemsReturnsListOfItemsInFoodSlot()
        {
            List<string> itemsInFoodSlot = _foodSlot.GetListOfItemsInSlot();
            Assert.IsNotNull(itemsInFoodSlot);
        }

        [TestMethod]
        public void TestFoodSlotAddsItemsItReceivesToList()
        {
            List<string> itemsInFoodSlot = _foodSlot.GetListOfItemsInSlot();
            Assert.AreEqual(0,itemsInFoodSlot.Count);
            _foodSlot.AcceptFood("Soda");
            Assert.AreEqual(1, itemsInFoodSlot.Count);
            Assert.AreEqual("Soda", itemsInFoodSlot[0]);
        }

        [TestMethod]
        public void TestFoodIsRemovedFromSlot()
        {
            List<string> itemsInFoodSlot = _foodSlot.GetListOfItemsInSlot();
            _foodSlot.AcceptFood("Soda");
            Assert.AreEqual(1, itemsInFoodSlot.Count);
            _foodSlot.RemoveItems();
            Assert.AreEqual(0, itemsInFoodSlot.Count);
        }
    }
}
