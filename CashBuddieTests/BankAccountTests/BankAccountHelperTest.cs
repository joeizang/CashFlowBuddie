using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using CashBuddie.Web.Models.InputModels;
using CashBuddie.Web.Infrastructure.Services;
using CashBuddie.Web.Models;

namespace CashBuddieTests.BankAccountTests
{
    /// <summary>
    /// Summary description for BankAccountHelperTest
    /// </summary>
    [TestClass]
    public class BankAccountHelperTest
    {
        public BankAccountHelperTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestPrepareResultModel()
        {
            //Arrange
            var input = new BankAccountInputModel
            {
                SearchString = "Something",
                Page = 1
            };
            var helper = new BankAccountHelper();

            //Act
            var result = helper.PrepareResultModel(input);

            //Assert
            Assert.AreEqual(helper, result);
        }

        [TestMethod]
        public void TestFilterOnContext()
        {
            //Mark that this is an Integration Test
            //Arrange
            var inputval = new BankAccountInputModel
            {
                SearchString = "Another Search thing",
                Page = 2
            };

            var helper = new BankAccountHelper();
            var db = new CashBuddieContext();

            //Act
            var result = helper.PrepareResultModel(inputval).FilterOnContext(db);

            //Assert
            Assert.AreEqual(helper, result);
        }


        [TestMethod]
        public void TestSortBankAccountSet()
        {
            //Mark that this is another Integration Test
            //Arrange
            var inputval = new BankAccountInputModel
            {
                SearchString = "Another Search thing",
                Page = 2
            };

            var helper = new BankAccountHelper();
            var db = new CashBuddieContext();

            //Act
            var result = helper.PrepareResultModel(inputval).FilterOnContext(db).SortBankAccountSet();

            //Assert
            Assert.AreEqual(helper, result);
        }

        [TestMethod]
        public void TestToResultModel()
        {
            //Mark that this is another Integration Test
            //Arrange
            var inputval = new BankAccountInputModel
            {
                SearchString = "Another Search thing",
                Page = 2
            };

            var helper = new BankAccountHelper();
            var db = new CashBuddieContext();

            //Act
            var result = helper.PrepareResultModel(inputval)
                               .FilterOnContext(db)
                               .SortBankAccountSet()
                               .ToResultModel(inputval.Page.Value);

            //Assert
            Assert.IsInstanceOfType(result, typeof(BankAccountResultModel));
        }
    }
}
