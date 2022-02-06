using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TestMongo.Data;
using TestMongo.Entities;

namespace TestMongo.Services
{
    public class TestService : ITestService
    {
        private const string nameFile = "temp.csv";
        private readonly ITestRepository _repo;

        public TestService(ITestRepository repo)
        {
            _repo = repo;
        }

        public async Task Fetch(string url)
        {
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(new Uri(url), nameFile);

            using var streamReader = File.OpenText(nameFile);
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Comment = '#',
                AllowComments = true,
                Delimiter = ";",
            };
            using var csvReader = new CsvReader(streamReader, csvConfig);

            while (csvReader.Read())
            {
                var name = csvReader.GetField(0);
                var price = csvReader.GetField(1);

                var productInDB = await _repo.Get(name);

                if (productInDB is null)
                {
                    var newProduct = new Product()
                    {
                        ProductName = name,
                        LastPrice = price,
                        CountChange = 0,
                        DateLastChange = DateTime.UtcNow
                    };
                    await _repo.Create(newProduct);
                }
                else if(productInDB.LastPrice != price)
                {
                    productInDB.LastPrice = price;
                    productInDB.CountChange += 1;
                    productInDB.DateLastChange = DateTime.UtcNow;
                    await _repo.Update(productInDB);
                }
            }
        }

        public async Task<IEnumerable<Product>> List(int pageSize, int pageNumber)
        {
            var products = await _repo.GetAll();

            return products.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToList();
        }
    }
}
