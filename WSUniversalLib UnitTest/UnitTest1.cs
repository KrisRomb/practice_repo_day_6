using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSUniversalLib;
using System;

namespace WSUniversalLib_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Calculation library = new Calculation();
        
        [TestMethod]
        public void GetQuantityForProduct_NonExistentProductType()
        {
            var result = library.GetQuantityForProduct(4, 1, 1, 1, 1);
            Assert.IsTrue(result == -1);
        }
        [TestMethod]
        public void GetQuantityForProduct_RightCalculateQuantity()
        {
            var result = library.GetQuantityForProduct(3, 1, 15, 20, 45);
            Assert.AreEqual(114148, result);
        }
        [TestMethod]
        public void GetQuantityForProduct_NonExistentMaterialType()
        {
            var result = library.GetQuantityForProduct(3, 3, 15, 20, 45);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GetQuantityForProduct_NegativeLength()
        {
            var result = library.GetQuantityForProduct(3, 2, 15, 20, -1);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GetQuantityForProduct_NegativeWidth()
        {
            var result = library.GetQuantityForProduct(3, 1, 15, -20, 45);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GetQuantityForProduct_NegativeCount()
        {
            var result = library.GetQuantityForProduct(3, 1, -15, 20, 45);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GetQuantityForProduct_NegativeProductType()
        {
            var result = library.GetQuantityForProduct(-3, 1, 15, 20, 45);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GetQuantityForProduct_NegativeMaterialType()
        {
            var result = library.GetQuantityForProduct(1, -1, 15, 20, 45);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GetQuantityForProduct_ZeroCount()
        {
            var result = library.GetQuantityForProduct(1, 1, 0, 20, 45);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void GetQuantityForProduct_WrongCalculateQuantity()
        {
            var result = library.GetQuantityForProduct(3, 1, 15, 20, 45);
            Assert.AreNotEqual(-1, result);
        }
    }
}
