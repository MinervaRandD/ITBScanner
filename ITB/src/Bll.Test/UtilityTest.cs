using Asi.Itb.Bll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Bll.Test
{
    
    
    /// <summary>
    ///This is a test class for UtilityTest and is intended
    ///to contain all UtilityTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UtilityTest
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
        ///A test for Sha1Encrypt
        ///</summary>
        [TestMethod()]
        public void Sha1EncryptTest()
        {
            string text = "cRENO";
            string salt = "CgDz4LN-V6W38oZBY3aC";
            string expected = "82a78de48cfaee775ddd890f6feb6c7b913aab98";
            string actual;
            actual = Utility.Sha1Encrypt(text, salt);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Sha1Encrypt
        ///</summary>
        [TestMethod()]
        public void Sha1EncryptTest1()
        {
            string text = "123456";
            string expected = "e64556d92a3e67a3115cdde1642bde420c11d6e9";
            string actual;
            actual = Utility.Sha1Encrypt(text);
            Assert.AreEqual(expected, actual);
        }
    }
}
