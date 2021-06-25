using System;

namespace PaymentServiceDemo.Business
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int SourceAccount { get; set; }
        public int DestAccount { get; set; }
    }
}