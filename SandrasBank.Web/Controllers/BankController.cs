using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SandrasBank.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SandrasBank.Web.Controllers
{
    public class BankController : Controller
    {
        BankRepository bank = new BankRepository();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Deposit(int accountId, decimal amount)
        {
            if(CheckAccountExists(accountId))
            {
                try
                {
                    bank.Deposit(amount, accountId);
                    var account = bank.Accounts.SingleOrDefault(a => a.AcccountId == accountId);
                    TempData["Message"] = $"Nytt saldo på för kontonr {accountId}: {account.Balance} kr";
                }
                catch
                {
                    TempData["Message"] = "Fel belopp";
                }
                
            }
            else
            {
                TempData["Message"] = "Kontonummer saknas";
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Withdraw(int accountId, decimal amount)
        {
            if(CheckAccountExists(accountId))
            {
                try
                {
                    bank.Withdraw(amount, accountId);
                    var account = bank.Accounts.SingleOrDefault(a => a.AcccountId == accountId);
                    TempData["Message"] = $"Nytt saldo på för kontonr {accountId}: {account.Balance} kr";
                }
                catch
                {
                    TempData["Message"] = "Felaktigt belopp";
                }
                
            }
            else
            {
                TempData["Message"] = "Kontonummer saknas";
            }

            return RedirectToAction("Index");
        }

        public bool CheckAccountExists(int accountId)
        {
            return bank.Accounts.Any(a => a.AcccountId == accountId);
        }
        
    }
}
