using System;

namespace DesignPatterns.Domain.Models
{
    public class BankOptions
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string BaseURL { get; set; }
        public string DepositURI { get; set; }
        public string TransactionNumber { get; set; }
    }
}
