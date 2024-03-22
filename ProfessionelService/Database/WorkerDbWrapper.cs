using SharedLibrary.DTO;
using SharedLibrary.Entities;
using System.Data.SQLite;

namespace WorkerService.Database
{
    public class ProfessionalDbWrapper
    {
        private string _myConnectionString;
        private DbProvider _dbProvider;
        public ProfessionalDbWrapper(DbProvider dbProvider, string connectionString)
        {
            _dbProvider = dbProvider;
            _myConnectionString = connectionString;
        }

        public async Task<OperationResultWithData> Add(Worker worker)
        {
            try
            {
                var myCommands = new List<SQLiteCommand>();
                var myResponse = worker;

                using (SQLiteConnection connection = new SQLiteConnection(_myConnectionString))
                {
                    await connection.OpenAsync();
                    var alreadyExist = await Get(connection, worker.Name);
                    if (String.IsNullOrEmpty(alreadyExist.Name))
                    {
                        await using (var transaction = connection.BeginTransaction())
                        {
                            myCommands.Add(this.Add(connection, transaction, myResponse));
                            await _dbProvider.TransactionCommand(connection, myCommands, transaction);
                        }
                    }
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
            try
            {
                var myCommands = new List<SQLiteCommand>();
                using (SQLiteConnection connection = new SQLiteConnection(_myConnectionString))
                {
                    await connection.OpenAsync();
                    var alreadyExist = await Get(connection, name);
                    if (String.IsNullOrEmpty(alreadyExist.Name))
                    {
                        await using (var transaction = connection.BeginTransaction())
                        {
                            myCommands.Add(this.Delete(connection, transaction, name));
                            await _dbProvider.TransactionCommand(connection, myCommands, transaction);
                        }
                    }
                    else
                    {
                        return new OperationResult("user not in Db");
                    }
                }
                return new OperationResult();
            }
            catch (Exception ex)
            {
                return new OperationResult(ex.Message);
            }
        }

        public async Task<OperationResultWithData> Update(Worker worker)
        {
            try
            {
                var myCommands = new List<SQLiteCommand>();
                using (SQLiteConnection connection = new SQLiteConnection(_myConnectionString))
                {
                    await connection.OpenAsync();
                    var alreadyExist = await Get(connection, worker.Name);
                    if (String.IsNullOrEmpty(alreadyExist.Name))
                    {
                        await using (var transaction = connection.BeginTransaction())
                        {
                            myCommands.Add(this.Update(connection, transaction, worker));
                            await _dbProvider.TransactionCommand(connection, myCommands, transaction);
                        }
                    }
                    else
                    {
                        return new OperationResultWithData("user not in Db");
                    }
                }
                return new OperationResultWithData(worker);
            }
            catch (Exception ex)
            {
                return new OperationResultWithData(ex.Message);
            }
        }

        public async Task<Worker> Get(SQLiteConnection sQLiteConnection, string name)
        {
            var myRequest = "SELECT * FROM WORKERS WHERE name = '" + name + "'";
            var command = new SQLiteCommand(myRequest, sQLiteConnection);
            var worker = new Worker();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    if (reader.HasRows)
                    {
                        worker.Name = reader["name"].ToString();
                        worker.PhoneNumber = reader["phoneNumber"].ToString();
                        worker.Ranking = (int)Int64.Parse(reader["ranking"].ToString());
                        worker.Location = (int)Int64.Parse(reader["location"].ToString());
                    }
                }
            }
            return worker;
        }

        public async Task<List<Worker>> GetAll(SQLiteConnection sQLiteConnection)
        {
            var myRequest = "SELECT * FROM WORKERS";
            var command = new SQLiteCommand(myRequest, sQLiteConnection);
            var workers = new List<Worker>();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Worker worker = new();
                    if (reader.HasRows)
                    {
                        worker.Name = reader["name"].ToString();
                        worker.PhoneNumber = reader["phoneNumber"].ToString();
                        worker.Ranking = (int)Int64.Parse(reader["ranking"].ToString());
                        worker.Location = (int)Int64.Parse(reader["location"].ToString());
                    }
                    workers.Add(worker);
                }
            }
            return workers;
        }

        private SQLiteCommand Add(SQLiteConnection sQLiteConnection, SQLiteTransaction transaction, Worker worker)
        {
            SQLiteCommand myCommand = new SQLiteCommand("", sQLiteConnection, transaction);
            myCommand.CommandText = "INSERT INTO WORKERS (name, phoneNumber, ranking, location) VALUES (@1,@2,@3, @4)";
            var withBlock = myCommand.Parameters;
            withBlock.Clear();
            withBlock.Add(new SQLiteParameter("@1", worker.Name));
            withBlock.Add(new SQLiteParameter("@2", worker.PhoneNumber));
            withBlock.Add(new SQLiteParameter("@3", worker.Ranking));
            withBlock.Add(new SQLiteParameter("@4", worker.Location));
            return myCommand;
        }

        private SQLiteCommand Update(SQLiteConnection sQLiteConnection, SQLiteTransaction transaction, Worker worker)
        {
            SQLiteCommand myCommand = new SQLiteCommand("", sQLiteConnection, transaction);
            myCommand.CommandText = "UPDATE INTO WORKERS (name, phoneNumber, ranking, location) VALUES (@1,@2,@3, @4)";
            var withBlock = myCommand.Parameters;
            withBlock.Clear();
            withBlock.Add(new SQLiteParameter("@1", worker.Name));
            withBlock.Add(new SQLiteParameter("@2", worker.PhoneNumber));
            withBlock.Add(new SQLiteParameter("@3", worker.Ranking));
            withBlock.Add(new SQLiteParameter("@4", worker.Location));
            return myCommand;
        }

        private SQLiteCommand Delete(SQLiteConnection sQLiteConnection, SQLiteTransaction transaction, string name)
        {
            SQLiteCommand myCommand = new SQLiteCommand("", sQLiteConnection, transaction);
            myCommand.CommandText = "DELÉTE FROM WORKERS WHERE name = '" + name + "'";
            return myCommand;
        }
    }
}
