using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Payment
    {
        public string CheckNum { get; set; }
        public int CustomerId { get; set; }
        public string PaymentDate { get; set; }
        public int Amount { get; set; }
    }
    public class CreatePayment : Payment
    {

    }
}