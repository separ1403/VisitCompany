namespace Framework.Application
{
    public class OperationResult
    {
        public bool IsSucceeded { get; private set; }
        public string Message { get; private set; }
        public long EntityId { get; private set; }

        public OperationResult()
        {
            IsSucceeded = false;
        }

        public OperationResult Succeeded(string message, long entityId)
        {
            IsSucceeded = true;
            Message = message;
            EntityId = entityId;
            return this;
        }

        public OperationResult Succeeded(string message)
        {
            IsSucceeded = true;
            Message = message;
            return this;
        }

        public OperationResult Failed(string message)
        {
            Message = message;
            IsSucceeded = false;
            return this;
        }
    }
}
