using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashBuddie.Web.Models;
using CashBuddie.Web.Models.InputModels;
using System.Linq;
using CashFlowBuddie.Web.Entities;

namespace CashBuddieTests.BankAccountTests
{
    /// <summary>
    /// Summary description for BankAccountControllerTest
    /// </summary>
    [TestClass]
    public class BankAccountControllerTest
    {


        public BankAccountControllerTest()
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
        public void TestAccountExits()
        {
            //Arrange
            var model = new BankAccountEditModel();

            model.AccountBalance = 100.0m;
            model.AccountNumber = "1001385606";
            model.NameOfAccount = "Joseph Izang";
            model.InstitutionName = "Zenith Bank";
            model.Id = model.AccountNumber;

            var acct = new BankAccount(model);

            IQueryable<BankAccount> accounts = new List<BankAccount>() { acct }.AsQueryable();

            //Act
            var result = accounts.Any(a => a.Id.Equals(model.Id));


            //Assert
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestIfAccountDoesNotExist()
        {
            //Arrange
            var model = new BankAccountEditModel();

            model.AccountBalance = 100.0m;
            model.AccountNumber = "1001385606";
            model.NameOfAccount = "Joseph Izang";
            model.InstitutionName = "Zenith Bank";
            model.Id = model.AccountNumber;

            var model1 = new BankAccountEditModel();

            model1.AccountBalance = 100.0m;
            model1.AccountNumber = "7587878786";
            model1.NameOfAccount = "Joseph Izang";
            model1.InstitutionName = "Zenith Bank";
            model1.Id = model.AccountNumber;

            var acct = new BankAccount(model);
            var acct1 = new BankAccount(model1);

            IQueryable<BankAccount> accounts = new List<BankAccount>() { acct }.AsQueryable();

            //Act
            var result = accounts.Any(a => !a.Id.Equals(model1.Id));

            //Assert
            Assert.IsFalse(result);
        }
    }
}
