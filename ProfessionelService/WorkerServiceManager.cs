using LoggingService;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.DTO;
using SharedLibrary.Entities;
using SharedLibrary.Interfaces;
using System.Data.SQLite;
using WorkerService.Database;

namespace WorkerService
{
    public class WorkerServiceManager : IWorkerServiceManager
    {
        private ILogService<WorkerServiceManager> _logger;
        private IServiceProvider _serviceProvider;

        // GET current file where we are --> check differences for MAC and Windows
        private string workDir;
        private const string storageFileProfessionel = "SearchDocumentation.db";
        private string _connectionString;

        private DbProvider _dbProvider;
        private ProfessionalDbWrapper _dbWrapper;
        public WorkerServiceManager(ILogService<WorkerServiceManager> logger, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            if (_serviceProvider != null)
                _logger = _serviceProvider.GetRequiredService<ILogService<WorkerServiceManager>>();
            else
                _logger = logger;

            workDir = Path.GetFullPath(System.IO.Directory.GetCurrentDirectory());
            _connectionString = $"Data Source={workDir}\\{storageFileProfessionel};Pooling=true;FailIfMissing=false;Version=3;Foreign Keys=true";
            _dbProvider = new DbProvider(_connectionString, serviceProvider);
            _dbWrapper = new ProfessionalDbWrapper(_dbProvider, _connectionString);
        }

        public async Task<OperationResultWithData> Add(Worker worker)
        {
            try
            {
                return await _dbWrapper.Add(worker);
            }
            catch (Exception ex)
            {
                return new OperationResultWithData(false, ex.Message);
            }
        }

        public async Task<OperationResultWithData> Get(string name)
        {
            try
            {
                Worker worker;
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    worker = await _dbWrapper.Get(connection, name);
                }
                return new OperationResultWithData(worker);
            }
            catch (Exception ex)
            {
                return new OperationResultWithData(false, ex.Message);
            }
        }

        public async Task<OperationResultWithData> GetAll()
        {
            try
            {
                List<Worker> worker;
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    worker = await _dbWrapper.GetAll(connection);
                }
                return new OperationResultWithData(worker);
            }
            catch (Exception ex)
            {
                return new OperationResultWithData(false, ex.Message);
            }
        }

        public async Task<OperationResult> Delete(string name)
        {
            return await _dbWrapper.Delete(name);
        }

        public async Task<OperationResultWithData> Update(Worker worker)
        {
            return await _dbWrapper.Update(worker);
        }
    }
}
