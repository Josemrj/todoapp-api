using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{
    public class TodoModel(string descricao)
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public DateTime DataConclusao { get; private set; }
        public string Descricao { get; private set; } = descricao;
        public bool IsConcluido { get; private set; }

        public TodoModel Update(string descricao)
        {
            Descricao = descricao;
            return this;
        }

        public TodoModel SetIsConcluido(bool isCocluido)
        {
            IsConcluido = isCocluido;
            DataConclusao = DateTime.Now;
            return this;
        }
    }
}
