using Microsoft.VisualStudio.TestTools.UnitTesting;
using SandrasBank.Web.Models;
using System;
using System.Linq;

namespace SandrasBank.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDeposit()
        {
            // Arrange
            var bank = new BankRepository();
            var account = bank.Accounts.SingleOrDefault(a => a.AcccountId == 1);
            var balanceBefore = account.Balance;

            // Act
            bank.Deposit(100m, account.AcccountId);

            // Assert
            Assert.AreEqual((balanceBefore + 100), account.Balance);
        }

        [TestMethod]
        public void TestWithdraw()
        {
            // Arrange
            var bank = new BankRepository();
            var account = bank.Accounts.SingleOrDefault(a => a.AcccountId == 1);
            var balanceBefore = account.Balance;

            // Act
            bank.Withdraw(100m, account.AcccountId);

            // Assert
            Assert.AreEqual((balanceBefore - 100), account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAmountToHigh()
        {
            var bank = new BankRepository();
            bank.Withdraw(1000000000000m, 1);

        }

        [TestMethod]
        public void TestTransfer()
        {
            var bank = new BankRepository();


            var accountFrom = bank.Accounts.SingleOrDefault(x => x.AcccountId == 1);
            var accountTo = bank.Accounts.SingleOrDefault(x => x.AcccountId == 2);
            var balanceBeforeFrom = accountFrom.Balance;
            var balanceBeforeTo = accountTo.Balance;

            bank.Transfer(accountFrom.AcccountId, accountTo.AcccountId, 100);

            Assert.AreEqual((balanceBeforeFrom - 100), accountFrom.Balance);
            Assert.AreEqual((balanceBeforeTo + 100), accountTo.Balance);
        }
    }
}
