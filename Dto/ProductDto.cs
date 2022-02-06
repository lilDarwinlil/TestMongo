using System;

namespace TestMongo.Dto
{
    public class ProductDto
    {
        /// <summary>
        /// Название товара
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Последняя цена
        /// </summary>
        public string LastPrice { get; set; }

        /// <summary>
        /// Количество изменений цены
        /// </summary>
        public int CountChange { get; set; }

        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        public DateTime DateLastChange { get; set; }
    }
}
