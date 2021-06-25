using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentServiceDemo.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentServiceDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(ILogger<PaymentsController> logger)
        {
            _logger = logger;
        }

        //GET: PaymentsController/Get
        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            var paymentList = new Payment[] {
            };

            return paymentList;
        }

        [HttpPost]
        public IEnumerable<Payment> SortPayments(IEnumerable<Payment> paymentList, string SortOrder)
        {
            IEnumerable<Payment> sortedPaymentList = paymentList;

            try
            {
                if (paymentList == null)
                {
                    throw new Exception("Payment List is empty");
                }
                if (string.IsNullOrEmpty(SortOrder))
                {
                    throw new Exception("Sort order List is empty");
                }

                foreach (var payment in paymentList)
                {
                    if (payment.Amount < 0)
                    {
                        throw new Exception("Payment Amount cannot be negative");
                    }
                }

                if (string.Compare(SortOrder, "date", true) == 0)
                {
                    //call sort class and return sorted list
                    sortedPaymentList = paymentList.OrderBy(x => x.DateSubmitted).ToList();
                }
                if (string.Compare(SortOrder, "amount", true) == 0)
                {
                    //call sort class and return sorted list
                    sortedPaymentList = paymentList.OrderBy(x => x.Amount).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return sortedPaymentList;
        }

        //[HttpPost]
        //public ReturnPOCO<IEnumerable<Payment>> SortPayments(IEnumerable<Payment> paymentList, string SortOrder)
        //{
        //    ReturnPOCO<IEnumerable<Payment>> retObj = new ReturnPOCO<IEnumerable<Payment>>();
        //    retObj.Status = StatusType.Success;
        //    retObj.Message = "";
        //    retObj.Data = paymentList;

        //    try
        //    {
        //        IEnumerable<Payment> sortedPaymentList = paymentList;
        //        if (paymentList == null)
        //        {
        //            retObj.Data = null;
        //            retObj.Message = "payment list is empty";
        //            retObj.Status = StatusType.Validation;
        //            return retObj;
        //        }
        //        if (string.IsNullOrEmpty(SortOrder))
        //        {
        //            retObj.Data = null;
        //            retObj.Message = "Sort Order is not specified";
        //            retObj.Status = StatusType.Validation;
        //            return retObj;
        //        }

        //        if (string.Compare(SortOrder, "date", true) == 0)
        //        {
        //            //call sort class and return sorted list
        //            retObj.Data = paymentList.OrderBy(x => x.DateSubmitted).ToList();
        //        }
        //        if (string.Compare(SortOrder, "amount", true) == 0)
        //        {
        //            //call sort class and return sorted list
        //            retObj.Data = paymentList.OrderBy(x => x.Amount).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        retObj.Status = StatusType.Fail;
        //        retObj.Message = ex.Message;
        //    }
        //    return retObj;
        //}
    }
}