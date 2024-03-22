namespace SharedLibrary.DTO
{
    public class OperationResultWithData
    {
        public dynamic? Data { get; private set; }
        public bool Success { get; private set; }
        public string? ErrorMessage { get; set; }

        public OperationResultWithData(dynamic data)
        {
            Success = true;
            Data = data;
        }

        public OperationResultWithData(bool success, string? errorMessage)
        {
            Success = success;
            ErrorMessage = errorMessage;
        }
    }
}
