using Asi.Itb.Bll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Bll.Test
{
    
    
    /// <summary>
    ///This is a test class for ConnectionManagerTest and is intended
    ///to contain all ConnectionManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConnectionManagerTest
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
        ///A test for Sync
        ///</summary>
        [TestMethod()]
        public void SyncTest()
        {
            ConnectionManager target = new ConnectionManager(); // TODO: Initialize to an appropriate value
            target.Sync(true);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for DownloadUpgradeFile
        ///</summary>
        [TestMethod()]
        public void DownloadUpgradeFileTest()
        {
            ConnectionManager target = new ConnectionManager(); // TODO: Initialize to an appropriate value
            Asi.Itb.Bll.DataContracts.DownLoadFile downLoadFile = new Asi.Itb.Bll.DataContracts.DownLoadFile();
            string fileName = string.Empty; // TODO: Initialize to an appropriate value
            int startByte = 0; // TODO: Initialize to an appropriate value
            int chunkSize = 0; // TODO: Initialize to an appropriate value
            Stream expected = null; // TODO: Initialize to an appropriate value
            Stream actual;
            actual = target.DownloadUpgradeFile(downLoadFile);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ConnectionManager Constructor
        ///</summary>
        [TestMethod()]
        public void ConnectionManagerConstructorTest()
        {
            ConnectionManager target = new ConnectionManager();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
