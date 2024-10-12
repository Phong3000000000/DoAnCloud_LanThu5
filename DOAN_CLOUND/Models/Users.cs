using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DOAN_CLOUND.Models
{
    public class KhachHang
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("HOTEN")]
        public string HOTEN { get; set; }

        [BsonElement("CHUCVU")]
        public string CHUCVU { get; set; }

        [BsonElement("MANV_QUANLY")]
        public string MANV_QUANLY { get; set; }

        [BsonElement("NGAYSINH")]
        public string NGAYSINH { get; set; }
        [BsonElement("GIOITINH")]
        public string GIOITINH { get; set; }
        [BsonElement("CMND")]
        public string CMND { get; set; }
        [BsonElement("EMAIL")]
        public string EMAIL { get; set; }
        [BsonElement("ROLE")]
        public string ROLE { get; set; }
        [BsonElement("DIACHI")]
        public string DIACHI { get; set; }
        [BsonElement("SODT")]
        public string SODT { get; set; }

        [BsonElement("USERNAME")]
        public string UserName { get; set; }

        [BsonElement("PASSWORD")]
        public string Pass { get; set; }
    }

}