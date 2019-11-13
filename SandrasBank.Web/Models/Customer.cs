using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandrasBank.Web.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
    }
}
