using System;
using CashBuddie.Web.Abstractions;
using CashBuddie.Web.Controllers;
using CashBuddie.Web.Models;
using CashBuddie.Web.Models.InputModels;
using CashFlowBuddie.Web.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace CashBuddieTests.CashFlowTests
{
    [TestClass]
    public class TestCashFlowController
    {
        [TestMethod]
        public void TestDetailActionProjectionLogic()
        {
            //Arrange
            var createcash = new CreateCashFlowModel
            {
                BankAccount = new BankAccountVM { Id = "1234567890"},
                Amount = 1234.567m,
                CashFlowSouce = new CashFlowSourceVM(),
                CashFlowType = new CashFlowTypeVM(),
                Description = "Testing 1234",
                AccountId = "1234567890",
                
            };


            var entity = new CashFlow(createcash);

            var db = new CashBuddieContext();
            var helper = Substitute.For<ICashBuddieHelper>();

            //Act
            var cashctrl = new CashFlowController(db, helper);
        }
    }
}
