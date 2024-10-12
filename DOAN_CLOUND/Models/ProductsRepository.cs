using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOAN_CLOUND.Models
{
    public class ProductsRepository
    {
        private readonly IMongoCollection<Products> _Products_collection;

        public ProductsRepository()
        {
            var client = new MongoClient("mongodb+srv://susu123:Susu123@thanhson.9xd9p.mongodb.net/");
            var database = client.GetDatabase("UngDungQuanCaFe");
            _Products_collection = database.GetCollection<Products>("Products");
        }

        // phương thức chức năng
        public List<Products> GetAll()
        {
            return _Products_collection.Find(product => true).ToList();
        }

        public Products GetById(string id)
        {
            return _Products_collection.Find(product => product.Id == id).FirstOrDefault();
        }

        public void AddProduct(Products product)
        {
            _Products_collection.InsertOne(product);
        }

        public void DeleteProduct(string id)
        {
            var filter = Builders<Products>.Filter.Eq(p => p.Id, id);
            _Products_collection.DeleteOne(filter);
        }

        public void UpdateProduct(string id, Products updatedProduct)
        {
            var filter = Builders<Products>.Filter.Eq(p => p.Id, id);
            var update = Builders<Products>.Update
                .Set(p => p.tenhang, updatedProduct.tenhang)
                .Set(p => p.dvt, updatedProduct.dvt)
                .Set(p => p.cate_id, updatedProduct.cate_id);
            _Products_collection.UpdateOne(filter, update);
        }



    }
}