using Asi.Itb.Bll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Asi.Itb.Bll.Entities;
using System.Collections.Generic;

namespace Bll.Test
{
    
    
    /// <summary>
    ///This is a test class for ScanManagerTest and is intended
    ///to contain all ScanManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ScanManagerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for SaveLocalScan
        ///</summary>
        [TestMethod()]
        public void SaveLocalScanTest()
        {
            ScanManager target = new ScanManager(); // TODO: Initialize to an appropriate value
            Scan scanData = null; // TODO: Initialize to an appropriate value
            target.SaveLocalScan(scanData);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SaveExternalScan
        ///</summary>
        [TestMethod()]
        public void SaveExternalScanTest()
        {
            ScanManager target = new ScanManager(); // TODO: Initialize to an appropriate value
            Scan scanData = null; // TODO: Initialize to an appropriate value
            target.SaveExternalScan(scanData);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetScansByBarcode
        ///</summary>
        [TestMethod()]
        public void GetScansByBarcodeTest()
        {
            ScanManager target = new ScanManager(); // TODO: Initialize to an appropriate value
            string barcode = string.Empty; // TODO: Initialize to an appropriate value
            List<Scan> expected = null; // TODO: Initialize to an appropriate value
            List<Scan> actual;
            actual = target.GetScansByBarcode(barcode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBags
        ///</summary>
        [TestMethod()]
        public void GetBagsTest()
        {
            ScanManager target = new ScanManager(); // TODO: Initialize to an appropriate value
            Bag.Status status = new Bag.Status(); // TODO: Initialize to an appropriate value
            List<Bag> expected = null; // TODO: Initialize to an appropriate value
            List<Bag> actual;
            actual = target.GetBags(status);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBagCount
        ///</summary>
        [TestMethod()]
        public void GetBagCountTest()
        {
            ScanManager target = new ScanManager(); // TODO: Initialize to an appropriate value
            Bag.Status status = new Bag.Status(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetBagCount(status);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetBagByBarcode
        ///</summary>
        [TestMethod()]
        public void GetBagByBarcodeTest()
        {
            ScanManager target = new ScanManager(); // TODO: Initialize to an appropriate value
            string barcode = string.Empty; // TODO: Initialize to an appropriate value
            Bag expected = null; // TODO: Initialize to an appropriate value
            Bag actual;
            actual = target.GetBagByBarcode(barcode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ScanManager Constructor
        ///</summary>
        [TestMethod()]
        public void ScanManagerConstructorTest()
        {
            ScanManager target = new ScanManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
