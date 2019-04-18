using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace projetoAPI.DataAccess.Models
{
    public class Funcionario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdFuncionario { get; set; }

        [BsonElement("Nome")]
        public string NomeFuncionario { get; set; }

        [BsonElement("Idade")]
        public string IdadeFuncionario { get; set; }

        [BsonElement("Funcao")]
        public string FuncaoFuncionario { get; set; }
    }
}
