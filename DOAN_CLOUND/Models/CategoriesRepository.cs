using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace DOAN_CLOUND.Models
{
    public class CategoriesRepository
    {
        private readonly IMongoCollection<Category> _categories;
        //IMongoCollection: chủ yếu để thêm, xóa, sửa, truy vấn


        public CategoriesRepository()
        {
            //Kết nối tới MongoDB server
            //var client = new MongoClient("mongodb://localhost:27017");
            var client = new MongoClient("mongodb+srv://susu123:Susu123@thanhson.9xd9p.mongodb.net/");
            var database = client.GetDatabase("UngDungQuanCaFe"); // database có kiểu dl là IMongoDatabase
            _categories = database.GetCollection<Category>("Categories");
            //GetCollection là phương thức của kdl IMongoDatabase để lấy collection
        }

        // Hàm lấy danh sách tất cả danh mục sp
        public List<Category> GetAllCategories()
        {
            return _categories.Find(category => true).ToList();//category => true tức là không có điều kiện lọc nào -> lấy ra tca document
        }
        public Category GetCategoryById(string id)
        {
            return _categories.Find(category => category.Id == id).FirstOrDefault();
        }
        public void CreateCategory(Category category)
        {
            _categories.InsertOne(category);
        }
        public void DeleteCategory(string id)
        {
            _categories.DeleteOne(category => category.Id == id);
        }
        public void UpdateCategory(string id, Category category_item)
        {
            //// CÁCH 1:

            //var update = Builders<Category>.Update.Set(c => c.Id, id); //Builders là một phần của mongoDB c# driver để truy vấn, cập nhật, ...
            //                                                           //Update.Set: thiết lập giá trị mới cho 1 field của document
            //_categories.UpdateOne(category => category.Id == id, update);
            ////UpdateOne: 2 tham số
            //// 1 là Filter: lamda
            //// 2 là Update: là một biểu thức cập nhật (update expression)


            // CÁCH 2: ReplaceOne (filter, document mới) thay thế toàn bộ document cũ bằng một document mới.
            _categories.ReplaceOne(category => category.Id == id, category_item);
        }
    }
}