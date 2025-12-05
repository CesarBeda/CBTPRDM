using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P02.Models;

namespace P02.Services
{
    public class LivroDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public LivroDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Livro>().Wait();
        }

        public Task<List<Livro>> GetLivrosAsync()
            => _database.Table<Livro>().ToListAsync();

        public Task<int> SaveLivroAsync(Livro livro)
            => livro.Id == 0 ? _database.InsertAsync(livro) : _database.UpdateAsync(livro);

        public Task<int> DeleteLivroAsync(Livro livro)
            => _database.DeleteAsync(livro);
    }
}
