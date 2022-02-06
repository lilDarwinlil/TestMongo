using MongoDB.Driver;
using TestMongo.Entities;

namespace TestMongo.Data
{
    public interface ITestContext
    {
        IMongoCollection<Product> Products { get; }
    }
}
