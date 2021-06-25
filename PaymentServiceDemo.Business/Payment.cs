using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentServiceDemo.Business
{
    public class Payment
    {
        public decimal Amount { get; set; }

        public string Currency { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Submitted")]
        public DateTime DateSubmitted { get; set; }

        [Display(Name = "Source Account")]
        public int SourceAccount { get; set; }

        [Display(Name = "Destination Account")]
        public int DestAccount { get; set; }
    }
}