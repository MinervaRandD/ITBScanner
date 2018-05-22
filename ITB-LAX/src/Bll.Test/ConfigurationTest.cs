using Asi.Itb.Bll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Bll.Test
{
    
    
    /// <summary>
    ///This is a test class for ConfigurationTest and is intended
    ///to contain all ConfigurationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConfigurationTest
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
        ///A test for WebServiceUri
        ///</summary>
        [TestMethod()]
        public void WebServiceUriTest()
        {
            Configuration_Accessor target = new Configuration_Accessor(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.WebServiceUri = expected;
            actual = target.WebServiceUri;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Version
        ///</summary>
        [TestMethod()]
        public void VersionTest()
        {
            Configuration_Accessor target = new Configuration_Accessor(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Version = expected;
            actual = target.Version;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Instance
        ///</summary>
        [TestMethod()]
        public void InstanceTest()
        {
            Configuration actual;
            actual = Configuration.Instance;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DbFilePath
        ///</summary>
        [TestMethod()]
        public void DbFilePathTest()
        {
            Configuration_Accessor target = new Configuration_Accessor(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.DbFilePath = expected;
            actual = target.DbFilePath;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LoadInstanceFromFile
        ///</summary>
        [TestMethod()]
        public void LoadInstanceFromFileTest()
        {
            Configuration.LoadInstanceFromFile();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Configuration Constructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Asi.Itb.Bll.dll")]
        public void ConfigurationConstructorTest()
        {
            Configuration_Accessor target = new Configuration_Accessor();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
