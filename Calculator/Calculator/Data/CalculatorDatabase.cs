using Calculator.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Data
{
    public class CalculatorDatabase : ICalculatorDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public CalculatorDatabase(string databasePath)
        {
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<CalculatorItem>().Wait();
        }

        public Task<List<CalculatorItem>> GetAll() => _database.Table<CalculatorItem>().ToListAsync();

        public Task<int> Insert(CalculatorItem item) =>
            item.Id != 0 ? _database.UpdateAsync(item) : _database.InsertAsync(item);

        public Task<int> Delete(CalculatorItem item) => _database.DeleteAsync(item);

        public Task<int> DeleteAll() => _database.DeleteAllAsync<CalculatorItem>();
    }
}