using LoggingService;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.DTO;
using System.Data.SQLite;

namespace WorkerService.Database
{
    public class DbProvider
    {
        private readonly ILogService<DbProvider> _logger;
        public SQLiteConnection _myConnection;
        private string _myConnectionString;

        public DbProvider(string connectionString, IServiceProvider serviceProvider, ILogService<DbProvider> logger = null)
        {
            if (serviceProvider != null)
                _logger = serviceProvider.GetRequiredService<ILogService<DbProvider>>();
            else
                _logger = logger;

            _myConnectionString = connectionString;
        }

        public async Task SetWorkDir()
        {
            _myConnection = await GetConnection(_myConnectionString);
            await InitDb(_myConnection);
            await _myConnection.CloseAsync();
        }

        private async Task<SQLiteConnection> GetConnection(string connectionString)
        {
            var connection = new SQLiteConnection();
            connection.ConnectionString = connectionString;
            await connection.OpenAsync();
            return connection;
        }

        private static IEnumerable<string> GetInitSQLStatement()
        {
            yield return @"CREATE TABLE IF NOT EXISTS WORKERS (
                            name TEXT,
                            phoneNumber TEXT,
                            location TEXT,
                            ranking INTEGER,
                            ); ";
        }

        private async Task InitDb(SQLiteConnection myConnection)
        {
            await InitialisationCommand(myConnection, GetInitSQLStatement());
        }

        private async Task InitialisationCommand(SQLiteConnection connection, IEnumerable<string> commands)
        {
            await using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    foreach (var sql in commands)
                    {
                        await using (var command = new SQLiteCommand(sql, connection, transaction))
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    _logger.LogError("DbProvider issue while InitialisationCommand" + ex.Message);
                }
                await transaction.CommitAsync();
            }
        }


        public async Task<OperationResult> TransactionCommand(SQLiteConnection connection, List<SQLiteCommand> myCommands, SQLiteTransaction transaction)
        {
            try
            {
                foreach (SQLiteCommand myCommand in myCommands)
                {
                    await myCommand.ExecuteNonQueryAsync();
                }
                await transaction.CommitAsync();
                return new OperationResult();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                _logger.LogError("DbProvider issue while TransactionCommand: " + ex.Message);
                return new OperationResult("DbProvider issue while TransactionCommand: " + ex.Message);
            }
        }
    }
}
