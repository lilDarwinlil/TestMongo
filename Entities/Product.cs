using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TestMongo.Entities
{
    public class Product
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

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
