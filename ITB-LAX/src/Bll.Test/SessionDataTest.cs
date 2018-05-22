using Asi.Itb.Bll.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Bll.Test
{
    
    
    /// <summary>
    ///This is a test class for SessionDataTest and is intended
    ///to contain all SessionDataTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SessionDataTest
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
        ///A test for User
        ///</summary>
        [TestMethod()]
        public void UserTest()
        {
            SessionData target = new SessionData(); // TODO: Initialize to an appropriate value
            User expected = null; // TODO: Initialize to an appropriate value
            User actual;
            target.User = expected;
            actual = target.User;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Message
        ///</summary>
        [TestMethod()]
        public void MessageTest()
        {
            SessionData target = new SessionData(); // TODO: Initialize to an appropriate value
            Message expected = null; // TODO: Initialize to an appropriate value
            Message actual;
            target.Message = expected;
            actual = target.Message;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Location
        ///</summary>
        [TestMethod()]
        public void LocationTest()
        {
            SessionData target = new SessionData(); // TODO: Initialize to an appropriate value
            Location expected = null; // TODO: Initialize to an appropriate value
            Location actual;
            target.Location = expected;
            actual = target.Location;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GpsPosition
        ///</summary>
        [TestMethod()]
        public void GpsPositionTest()
        {
            SessionData target = new SessionData(); // TODO: Initialize to an appropriate value
            GpsPosition expected = null; // TODO: Initialize to an appropriate value
            GpsPosition actual;
            target.GpsPosition = expected;
            actual = target.GpsPosition;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Current
        ///</summary>
        [TestMethod()]
        public void CurrentTest()
        {
            SessionData actual;
            actual = SessionData.Current;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for BagCountStatus
        ///</summary>
        [TestMethod()]
        public void BagCountStatusTest()
        {
            SessionData target = new SessionData(); // TODO: Initialize to an appropriate value
            Bag.Status expected = new Bag.Status(); // TODO: Initialize to an appropriate value
            Bag.Status actual;
            target.BagCountStatus = expected;
            actual = target.BagCountStatus;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Bag
        ///</summary>
        [TestMethod()]
        public void BagTest()
        {
            SessionData target = new SessionData(); // TODO: Initialize to an appropriate value
            Bag expected = null; // TODO: Initialize to an appropriate value
            Bag actual;
            target.Bag = expected;
            actual = target.Bag;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SessionData Constructor
        ///</summary>
        [TestMethod()]
        public void SessionDataConstructorTest()
        {
            SessionData target = new SessionData();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
