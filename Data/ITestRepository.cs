using System.Collections.Generic;
using System.Threading.Tasks;
using TestMongo.Entities;

namespace TestMongo.Data
{
    public interface ITestRepository
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> Get(string name);

        Task Create(Product product);

        Task<bool> Update(Product product);
    }
}
