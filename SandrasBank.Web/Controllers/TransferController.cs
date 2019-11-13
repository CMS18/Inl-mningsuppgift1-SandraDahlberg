using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SandrasBank.Web.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SandrasBank.Web.Controllers
{
    public class TransferController : Controller
    {
        BankRepository bank = new BankRepository();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transfer(int accountIdFrom, int accountIdTo, decimal amount)
        {
            if (CheckAccountExists(accountIdFrom) && CheckAccountExists(accountIdTo))
            {

                try
                {
                    bank.Transfer(accountIdFrom, accountIdTo, amount);
                    var accountFrom = bank.Accounts.SingleOrDefault(a => a.AcccountId == accountIdFrom);
                    var accountTo = bank.Accounts.SingleOrDefault(a => a.AcccountId == accountIdTo);
                    TempData["Message"] = $"Nytt saldo på för kontonr {accountIdFrom}: {accountFrom.Balance} kr;" +
                        $"Nytt saldo på för kontonr {accountIdTo}: {accountTo.Balance} kr; ";
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

        public bool CheckAccountExists(int accountId)
        {
            return bank.Accounts.Any(a => a.AcccountId == accountId);
        }
    }
}
