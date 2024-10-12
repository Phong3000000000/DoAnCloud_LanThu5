using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;


namespace DOAN_CLOUND.Models
{
    public class UsersRepository
    {
        private readonly IMongoCollection<KhachHang> _khachHangCollection;

        public UsersRepository()
        {
            // Chuỗi kết nối đến MongoDB
            var client = new MongoClient("mongodb+srv://susu123:Susu123@thanhson.9xd9p.mongodb.net/");
            //var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("UngDungQuanCaFe"); // Tên database là QL_CAPHE
            _khachHangCollection = database.GetCollection<KhachHang>("Users"); // Tên collection là KHACH
        }

        public List<KhachHang> GetAll()
        {
            return _khachHangCollection.Find(khach => true).ToList();
        }

        public KhachHang GetById(string id)
        {
            return _khachHangCollection.Find(khach => khach.Id == id).FirstOrDefault();
        }

        public void Add(KhachHang khachHang)
        {
            _khachHangCollection.InsertOne(khachHang);
        }

        public void Update(string id, KhachHang khachHang)
        {
            _khachHangCollection.ReplaceOne(khach => khach.Id == id, khachHang);
        }

        public void Delete(string id)
        {
            _khachHangCollection.DeleteOne(khach => khach.Id == id);
        }
        // commet test

        public int kiemtra(string username, string password)
        {
            // Sử dụng _khachHangCollection để tìm user với username và password
            var filter = Builders<KhachHang>.Filter.And(
             Builders<KhachHang>.Filter.Eq(kh => kh.UserName, username),
             Builders<KhachHang>.Filter.Eq(kh => kh.Pass, password)
            );


            // Kiểm tra xem có user nào thỏa mãn không
            var user = _khachHangCollection.Find(filter).FirstOrDefault();

            return user != null ? 1 : 0; // Trả về 1 nếu có user, 0 nếu không tìm thấy
        }
        public string lay_role(string username, string password)
        {
            if (kiemtra(username, password) == 1)
            {
                var filter = Builders<KhachHang>.Filter.And(
                   Builders<KhachHang>.Filter.Eq(kh => kh.UserName, username),
                   Builders<KhachHang>.Filter.Eq(kh => kh.Pass, password)
                  );
                var role = _khachHangCollection.Find(filter).FirstOrDefault();
                string role_real = role.ROLE;
                return role_real;
            }
            else return null;
        }
    }
}