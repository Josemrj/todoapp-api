using MongoDB.Driver;
using WebAPI.Configuration;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class TodoRepository
    {
        

        public TodoRepository(DbSettings dbSettings)
        {
            var database = new MongoClient().GetDatabase(dbSettings.DataBaseName);
            _todoCollection = database.GetCollection<Todo>("Todo");
        }

        protected IMongoCollection<Todo> _todoCollection;

        public async Task<Todo> GetAsync(string id, CancellationToken cancellationToken)
        {
            return await _todoCollection.Find(f => f.Id == id).SingleAsync(cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await _todoCollection.DeleteOneAsync(f => f.Id == id, cancellationToken);
        }
    }
}
