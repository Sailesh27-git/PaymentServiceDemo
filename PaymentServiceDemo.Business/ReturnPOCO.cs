namespace PaymentServiceDemo.Business
{
    public class ReturnPOCO<T>
    {
        public string Message { get; set; }
        public StatusType Status { get; set; }

        public T Data { get; set; }
    }

    public enum StatusType { Success = 0, Fail = 1, Validation = 2 }
}