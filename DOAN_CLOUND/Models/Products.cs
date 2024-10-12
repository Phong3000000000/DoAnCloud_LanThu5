using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CLOUND.Models
{
    public class Products
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("TENHANG")]
        public string tenhang { get; set; }

        [BsonElement("DVT")]
        public string dvt { get; set; }

        [BsonElement("CATE_ID")]
        public string cate_id { get; set; }
    }
}