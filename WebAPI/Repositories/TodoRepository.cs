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
            _collection = database.GetCollection<TodoModel>("Todo");
        }

        protected IMongoCollection<TodoModel> _collection;

        // Buscar todos os registros da coleção
        public async Task<List<TodoModel>> GetFileAsync(CancellationToken cancellationToken)
        {
            return await _collection.Find(f => true).ToListAsync(cancellationToken);
        }

        // Buscar registros da coleção por ids
        public async Task<List<TodoModel>> GetFileAsync(List<string> ids, CancellationToken cancellationToken)
        {
            return await _collection.Find(f => ids.Contains(f.Id)).ToListAsync(cancellationToken);
        }

        // Buscar um registro da coleção
        public async Task<TodoModel> GetFileAsync(string id, CancellationToken cancellationToken)
        {
            return await _collection.Find(f => f.Id == id).SingleAsync(cancellationToken);
        }

        public async Task<List<TodoModel>> SearchAsync(string search, CancellationToken cancellationToken)
        {
            return await _collection.Find(w => string.IsNullOrEmpty(search) || w.Descricao.Contains(search)).ToListAsync(cancellationToken);
        }

        // Inserir um registro na coleção
        public async Task InsertOneAsync(TodoModel model, CancellationToken cancellationToken)
        {
            await _collection.InsertOneAsync(model, cancellationToken: cancellationToken);
        }

        // Atualizar um registro na coleção
        public async Task UpdateAsync(TodoModel todomodel, CancellationToken cancellationToken)
        {
            await _collection.ReplaceOneAsync(todomodel.Id, todomodel, cancellationToken: cancellationToken);
        }

        // Atualizar registros da colecao por ids
        public async Task UpdateAsync(List<TodoModel> todoModels, CancellationToken cancellationToken)
        {
            foreach (var todoModel in todoModels)
                await _collection.ReplaceOneAsync(todoModel.Id, todoModel, cancellationToken: cancellationToken);
        }

        // Deletar um registro na coleção
        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await _collection.DeleteOneAsync(f => f.Id == id, cancellationToken);
        }

    }
}
