using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared.ComplexTypes
{
    public class OperationResult<TResult>
    {
        private OperationResult() { }

        public bool Success { get; private set; }
        public TResult ResultData { get; private set; }
        public string ErrorMessage { get; private set; }
        public Exception Exception { get; private set; }
        public OperationStatus Status { get; private set; } = OperationStatus.None;

        public static OperationResult<TResult> CreateSuccessResult(TResult result, OperationStatus operationStatus)
        {
            return new OperationResult<TResult> { Success = true, ResultData = result, Status = operationStatus };
        }

        public static OperationResult<TResult> CreateFailure(Exception ex, OperationStatus operationStatus)
        {
            return new OperationResult<TResult>
            {
                Success = false,
                //ErrorMessage = $"{ex.Message} {Environment.NewLine} {ex.StackTrace}",
                ErrorMessage = ex.Message,
                Exception = ex,
                Status = operationStatus
            };
        }
    }

    public enum OperationStatus
    {
        None,
        Ok,
        Error,
        Exception,
        Duplicate,
        NotFound,
        Created,
        Updated,
        Deleted
    }
}
