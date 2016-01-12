namespace AppInsurance.Base
{
    public abstract class ResponseBase
    {
        public ExecutionStatus Status { get; set; }
        public string ErrorMessage { get; set; }
    }

    public enum ExecutionStatus
    {
        NotExecuted, TechnicalError, BusinessError, Success
    }
}
