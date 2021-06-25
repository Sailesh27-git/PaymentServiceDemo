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

        /// <summary>
        /// The default method invoked on application start
        /// Returns a list of 5 payments
        /// </summary>
        /// <returns></returns>
        //GET: PaymentsController/Get
        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            var paymentList = new Payment[] {
                new Payment { Amount = 2000,Currency = "Pounds", DateSubmitted=new DateTime(2020,2,25),SourceAccount =1234, DestAccount=1122 },
                new Payment { Amount = 100,Currency = "Dollars", DateSubmitted=new DateTime(2021,2,25),SourceAccount =1234, DestAccount=1122 },
                new Payment { Amount = 400,Currency = "Rupee", DateSubmitted=new DateTime(2015,3,25),SourceAccount =1234, DestAccount=1122 },
                new Payment { Amount = 10,Currency = "Dhiram", DateSubmitted=new DateTime(2016,5,25),SourceAccount =1234, DestAccount=1122 },
                new Payment { Amount = 4000,Currency = "Rouble", DateSubmitted=new DateTime(2013,1,25),SourceAccount =1234, DestAccount=1122 },
            };

            return paymentList;
        }

        /// <summary>
        ///Sorts the submitted payments based on the specified sort order
        /// </summary>
        /// <param name="paymentList"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        [HttpPost]
        public IEnumerable<Payment> SortPayments(IEnumerable<Payment> paymentList, string sortOrder)
        {
            IEnumerable<Payment> sortedPaymentList = paymentList;

            //try
            {
                if (paymentList == null)
                {
                    throw new ArgumentException($"Payment list {paymentList} cannot be empty.", nameof(paymentList));
                }
                if (string.IsNullOrEmpty(sortOrder))
                {
                    throw new ArgumentException($"Sort order {sortOrder} cannot be empty.", nameof(sortOrder));
                }

                foreach (var payment in paymentList)
                {
                    if (payment.Amount < 0)
                    {
                        throw new Exception("Payment Amount cannot be negative");
                    }
                }

                if (string.Compare(sortOrder, "date", true) == 0)
                {
                    //call sort class and return sorted list
                    sortedPaymentList = paymentList.OrderBy(x => x.DateSubmitted).ToList();
                }
                if (string.Compare(sortOrder, "amount", true) == 0)
                {
                    //call sort class and return sorted list
                    sortedPaymentList = paymentList.OrderBy(x => x.Amount).ToList();
                }
            }
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, ex.Message);
            //}
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