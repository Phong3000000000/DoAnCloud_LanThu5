using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DOAN_CLOUND.Models
{
    public class Bill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("MAHD")]
        public string MAHD { get; set; }

        [BsonElement("NGAYLAP")]
        public string NGAYLAP { get; set; }

        [BsonElement("TRANGTHAI")]
        public string TRANGTHAI { get; set; }

        [BsonElement("MAKH")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MAKH { get; set; }

        [BsonElement("MANV")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MANV { get; set; }

        [BsonElement("BILL_DETAILS")]
        public List<BILL_DETAILS> BillDetails { get; set; } = new List<BILL_DETAILS>(); // Khởi tạo danh sách
    }
    public class BILL_DETAILS
    {
        [BsonElement("MAHG")]
        public string MAHG { get; set; }

        [BsonElement("SOLUONG")]
        public int SOLUONG { get; set; }

        [BsonElement("GIABAN")]
        public int GIABAN { get; set; }
    }
}