using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DOAN_CLOUND.Models
{
    public class BillRepository
    {
        private readonly IMongoCollection<Bill> _billCollection;

        public BillRepository()
        {
            // Chuỗi kết nối đến MongoDB
            var client = new MongoClient("mongodb+srv://susu123:Susu123@thanhson.9xd9p.mongodb.net/");
            var database = client.GetDatabase("UngDungQuanCaFe"); // Tên database là UngDungQuanCaFe
            _billCollection = database.GetCollection<Bill>("BILL"); // Tên collection là BILL
        }


        public BillRepository(IMongoDatabase database)
        {
            _billCollection = database.GetCollection<Bill>("BILL");
        }
        public async Task CreateAsync(Bill bill)
        {
            await _billCollection.InsertOneAsync(bill);
        }

        public async Task UpdateAsync(string id, Bill billIn)
        {
            await _billCollection.ReplaceOneAsync(b => b.Id == id, billIn);
        }
        public async Task<List<Bill>> GetAllAsync()
        {
            return await _billCollection.Find(bill => true).ToListAsync();
        }

        public async Task<Bill> GetByIdAsync(string id)
        {
            return await _billCollection.Find(b => b.Id == id).FirstOrDefaultAsync();
        }





        public List<Bill> GetAll()
        {
            return _billCollection.Find(bill => true).ToList();
        }




        public Bill GetById(string id)
        {
            return _billCollection.Find(bill => bill.Id == id).FirstOrDefault();
        }

        public void Add(Bill Bill)
        {
            _billCollection.InsertOne(Bill);
        }

        public void Update(string id, Bill Bill)
        {
            _billCollection.ReplaceOne(BILL => BILL.Id == id, Bill);
        }

        public void Delete(string id)
        {
            _billCollection.DeleteOne(BILL => BILL.Id == id);
        }

        // commet test
    }
}