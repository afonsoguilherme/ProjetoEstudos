using MongoDB.Driver;

namespace projetoAPI.DataAccess.Models
{
    public interface IMongoContext
    {
        IMongoCollection<Funcionario> CollectionFuncionario{ get; }
        
    }
}
