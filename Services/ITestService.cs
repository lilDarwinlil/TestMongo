using System.Collections.Generic;
using System.Threading.Tasks;
using TestMongo.Entities;

namespace TestMongo.Services
{
    public interface ITestService
    {
        /// <summary>
        /// Загрузка файла CSV и сохранение в БД
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task Fetch(string url);

        /// <summary>
        /// Выборка записей с пагинацией
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> List(int pageSize, int pageNumber);
    }
}
