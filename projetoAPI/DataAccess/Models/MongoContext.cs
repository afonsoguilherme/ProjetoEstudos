using System;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace projetoAPI.DataAccess.Models
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(IOptions<Configuracoes> options, IMongoClient client)
        {
            _db = client.GetDatabase(options.Value.Database);
        }

        
        public IMongoCollection<Funcionario> CollectionFuncionario => _db.GetCollection<Funcionario>("Funcionario");
        
    }
}
