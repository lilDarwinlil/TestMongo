using MongoDB.Driver;
using TestMongo.Config;
using TestMongo.Entities;

namespace TestMongo.Data
{
    public class TestContext : ITestContext
    {
        private readonly IMongoDatabase _db;
        public TestContext(MongoDBConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            _db = client.GetDatabase(config.Database);
        }
        public IMongoCollection<Product> Products => _db.GetCollection<Product>("Products");
    }
}
