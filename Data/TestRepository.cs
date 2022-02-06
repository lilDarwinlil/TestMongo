using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestMongo.Entities;

namespace TestMongo.Data
{
    public class TestRepository : ITestRepository
    {
        private readonly ITestContext _context;

        public TestRepository(ITestContext context)
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<Product> Get(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(m => m.ProductName, name);
            return await  _context
                    .Products
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context
                .Products
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task<bool> Update(Product product)
        {
            ReplaceOneResult updateResult = await _context
                .Products
                .ReplaceOneAsync(
                    filter: g => g.ProductName == product.ProductName,
                    replacement: product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
