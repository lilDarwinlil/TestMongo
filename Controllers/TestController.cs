using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestMongo.Dto;
using TestMongo.Entities;
using TestMongo.Services;

namespace TestMongo.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class TestController : Controller
    {
        private readonly ITestService _service;

        public TestController(ITestService service)
        {
            _service = service;
        }

        // Загрузка файла CSV и сохранение в БД
        [HttpPost]
        public async Task<IActionResult> Fetch(string url)
        {
            await _service.Fetch(url);
            return Ok();
        }

        // Выборка записей с пагинацией
        [HttpGet("{pageSize:int}/{pageNumber:int}")]
        public async Task<IActionResult> List(int pageSize, int pageNumber)
        {
            var products = await _service.List(pageSize, pageNumber);

            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDto>()));

            return Ok(mapper.Map<IEnumerable<ProductDto>>(products));
        }
    }
}
