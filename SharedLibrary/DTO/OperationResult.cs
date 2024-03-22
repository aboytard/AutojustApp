namespace SharedLibrary.DTO
{
    public class OperationResult
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public OperationResult() { }

        public OperationResult(string errorMessage)
        {
            Success = false;
            ErrorMessage = errorMessage;
        }
    }
}
