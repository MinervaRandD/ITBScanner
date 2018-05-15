using Asi.Itb.Bll.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bll.Test
{
    
    
    /// <summary>
    ///This is a test class for ScanTest and is intended
    ///to contain all ScanTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ScanTest
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
        ///A test for UserName
        ///</summary>
        [TestMethod()]
        public void UserNameTest()
        {
            Scan target = new Scan(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.UserName = expected;
            actual = target.UserName;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ScanTime
        ///</summary>
        [TestMethod()]
        public void ScanTimeTest()
        {
            Scan target = new Scan(); // TODO: Initialize to an appropriate value
            DateTime expected = new DateTime(); // TODO: Initialize to an appropriate value
            DateTime actual;
            target.ScanTime = expected;
            actual = target.ScanTime;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Operation
        ///</summary>
        [TestMethod()]
        public void OperationTest()
        {
            Scan target = new Scan(); // TODO: Initialize to an appropriate value
            Scan.ScanOperation expected = new Scan.ScanOperation(); // TODO: Initialize to an appropriate value
            Scan.ScanOperation actual;
            target.Operation = expected;
            actual = target.Operation;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LocationCode
        ///</summary>
        [TestMethod()]
        public void LocationCodeTest()
        {
            Scan target = new Scan(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.LocationCode = expected;
            actual = target.LocationCode;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsUploaded
        ///</summary>
        [TestMethod()]
        public void IsUploadedTest()
        {
            Scan target = new Scan(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsUploaded = expected;
            actual = target.IsUploaded;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Damaged
        ///</summary>
        [TestMethod()]
        public void DamagedTest()
        {
            Scan target = new Scan(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.Damaged = expected;
            actual = target.Damaged;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Barcode
        ///</summary>
        [TestMethod()]
        public void BarcodeTest()
        {
            Scan target = new Scan(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Barcode = expected;
            actual = target.Barcode;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Scan Constructor
        ///</summary>
        [TestMethod()]
        public void ScanConstructorTest()
        {
            Scan target = new Scan();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
