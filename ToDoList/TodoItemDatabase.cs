using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite;

namespace ToDoList
{
    public class TodoItemDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public TodoItemDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<TodoTask>().Wait();
        }

        public async Task<List<TodoTask>> GetTasksAsync()
        {
            return await _database.Table<TodoTask>().ToListAsync();
        }

        public Task<TodoTask> GetTaskAsync(int id)
        {
            return _database.Table<TodoTask>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SaveTaskAsync(TodoTask task)
        {
            try
            {
                if (task != null && task.Id != null && task.Id != 0)
                {
                    return await _database.UpdateAsync(task);
                }
                else if (task != null)
                {
                    return await _database.InsertAsync(task);
                }
                else
                {
                    throw new ArgumentNullException(nameof(task));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        internal Task CreateTableAsync<T>()
        {
            throw new NotImplementedException();
        }

        internal void CloseConnection()
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteTaskAsync(TodoTask task)
        {
            var existingTask = await GetTaskAsync(task.Id);
            if (existingTask != null)
            {
                return await _database.DeleteAsync(task);
            }
            else
            {
                return 0;
            }
        }


        public Task<List<TodoTask>> GetToDoTasksAsync()
        {
            return _database.Table<TodoTask>()
                            .Where(i => i.Status == "To Do")
                            .ToListAsync();
        }

        public Task<List<TodoTask>> GetInProgressTasksAsync()
        {
            return _database.Table<TodoTask>()
                            .Where(i => i.Status == "En cours")
                            .ToListAsync();
        }

        public Task<List<TodoTask>> GetCompletedTasksAsync()
        {
            return _database.Table<TodoTask>()
                            .Where(t => t.Status == "Terminée")
                            .ToListAsync();
        }
    }
}
