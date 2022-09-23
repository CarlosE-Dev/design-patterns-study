using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Domain.Models
{
    public class DepositMoney
    {
        public DateTime TransactionDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string ClientName { get; set; }
        public string TransactionNumber { get; set; }
    }
}
