using SharedLibrary.DTO;
using SharedLibrary.Entities;

namespace SharedLibrary.Interfaces
{
    public interface IWorkerServiceManager
    {
        Task<OperationResult> Delete(string name);

        Task<OperationResultWithData> Update(Worker worker);

        Task<OperationResultWithData> Add(Worker worker);

        Task<OperationResultWithData> Get(string name);

        Task<OperationResultWithData> GetAll();
    }
}
