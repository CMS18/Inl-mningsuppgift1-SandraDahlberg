using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandrasBank.Web.Models
{
    public class Account
    {
        public decimal Balance { get; set; }
        public int AcccountId { get; set; }
        public int CustomerId { get; set; }
    }
}
