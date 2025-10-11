﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ecommerce.Catalog.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string ProductDetailID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInformation { get; set; }

    }
}
