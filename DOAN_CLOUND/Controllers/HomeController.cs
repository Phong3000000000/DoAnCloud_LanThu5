using DOAN_CLOUND.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DOAN_CLOUND.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsersRepository UsersRepo = new UsersRepository();
        private readonly ProductsRepository ProductsRepo = new ProductsRepository();
        private readonly CategoriesRepository CategoryRepo = new CategoriesRepository();
        private readonly BillRepository BillRepo = new BillRepository();
        //================================================================================USER
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(KhachHang dn)
        {
            Session["loi"] = "Dang nhap khong thanh cong (sai thong tin)";
            Session["thongbao"] = "Dang nhap thanh cong";

            UsersRepository condn = new UsersRepository();
            string role = condn.lay_role(dn.UserName, dn.Pass);
            if (ModelState.IsValid)
            {
                ViewBag.kt = condn.kiemtra(dn.UserName, dn.Pass);
                

                if (ViewBag.kt == 0)
                {
                    return View();
                }
                else if(role == "ADMIN")
                {
                    return RedirectToAction("Index_User", "Home");
                }    
                else
                {
                    return RedirectToAction("index", "Home");
                }    
              
            }

            return View();
        }



        [HttpGet]
        public ActionResult Create_BILL()
        {
            var bill = new Bill();
            // Khởi tạo BillDetails với 1 dòng trống để người dùng thêm dữ liệu
            bill.BillDetails.Add(new BILL_DETAILS());
            return View(bill);
        }

        [HttpPost]
        public async Task<ActionResult> Create_BILL(Bill bill)
        {
            if (ModelState.IsValid)
            {
                await BillRepo.CreateAsync(bill);
                return RedirectToAction("Index_BILL");
            }
            return View(bill);
        }

        [HttpGet]
        public async Task<ActionResult> Edit_BILL(string id)
        {
            var bill = await BillRepo.GetByIdAsync(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        [HttpPost]
        public async Task<ActionResult> Edit_BILL(string id, Bill bill)
        {
            if (ModelState.IsValid)
            {
                await BillRepo.UpdateAsync(id, bill);
                return RedirectToAction("Index_BILL");
            }
            return View(bill);
        }




        public ActionResult Index_BILL()
        {
            // List<Bill> bills = _billRepo.GetAll();
            var billList = BillRepo.GetAll();
            return View(billList);
        }

        // GET: /Bill/Details/{id}
        [HttpGet]
        public ActionResult BILL_DETAILS(string id)
        {
            Bill bill = BillRepo.GetById(id); // Fetch the bill by its ObjectId
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill); // Return the bill to the view for display
        }


        public ActionResult Details_Bill(string id)
        {
            var bill = BillRepo.GetById(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }


        // GET: Bill/Create
       

        // GET: Bill/Edit/5
        public ActionResult Edit_Bill(string id)
        {
            var bill = BillRepo.GetById(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bill/Edit/5
        [HttpPost]
        public ActionResult Edit_Bill(string id, Bill bill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BillRepo.Update(id, bill);
                    return RedirectToAction("Index");
                }
                return View(bill);
            }
            catch
            {
                return View();
            }
        }

        // GET: Bill/Delete/5
        public ActionResult Delete_Bill(string id)
        {
            var bill = BillRepo.GetById(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bill/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed_BILL(string id)
        {
            try
            {
                BillRepo.Delete(id);
                return RedirectToAction("Index_BILL");
            }
            catch
            {
                return View();
            }
        }
        //================================================================================USER
        // GET: KhachHang
        public ActionResult Index_User()
        {
            var UserList = UsersRepo.GetAll();
            return View(UserList);
        }

        // GET: KhachHang/Details/5
        public ActionResult Details_User(string id)
        {
            var User = UsersRepo.GetById(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        // GET: KhachHang/Create
        public ActionResult Create_User()
        {
            return View();
        }

        // POST: KhachHang/Create
        [HttpPost]
        public ActionResult Create_User(KhachHang khachHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsersRepo.Add(khachHang);
                    return RedirectToAction("Index_User");
                }
                return View(khachHang);
            }
            catch
            {
                return View();
            }
        }

        // GET: KhachHang/Edit/5
        public ActionResult Edit_User(string id)
        {
            var khachHang = UsersRepo.GetById(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHang/Edit/5
        [HttpPost]
        public ActionResult Edit_User(string id, KhachHang khachHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsersRepo.Update(id, khachHang);
                    return RedirectToAction("Index_User");
                }
                return View(khachHang);
            }
            catch
            {
                return View();
            }
        }

        // GET: KhachHang/Delete/5
        public ActionResult Delete_User(string id)
        {
            var khachHang = UsersRepo.GetById(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                UsersRepo.Delete(id);
                return RedirectToAction("Index_User");
            }
            catch
            {
                return View();
            }
        }
        //================================================================================PRODUCTS
        // GET: Products
        public ActionResult Index_Products()
        {
            var ProductsList = ProductsRepo.GetAll();
            return View(ProductsList);
        }
        // GET: KhachHang/Details/5
        public ActionResult Details_Products(string id)
        {
            var User = ProductsRepo.GetById(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }

        // GET: Products/Create
        [HttpGet]
        public ActionResult Create_Products()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Products(Products product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductsRepo.AddProduct(product); // Phương thức thêm sản phẩm
                    return RedirectToAction("Index_Products");

                }
                return View(product);
            }
            catch (Exception)
            {

                return View(); // Trả về view nếu Model không hợp lệ

            }

        }


        // GET: Products/Delete/id
        public ActionResult Delete(string id)
        {
            var product = ProductsRepo.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed_Products(string id)
        {
            ProductsRepo.DeleteProduct(id);
            return RedirectToAction("Index_Products");
        }

        // GET: Products/Edit/id
        public ActionResult Edit_Product(string id)
        {
            var product = ProductsRepo.GetById(id); // Lấy sản phẩm theo id
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Product(string id, Products product)
        {
            if (ModelState.IsValid)
            {
                ProductsRepo.UpdateProduct(id, product); // Phương thức cập nhật sản phẩm
                return RedirectToAction("Index_Products");
            }
            return View(product);
        }




        //================================================================================CATEGORY
        // GET: Category
        public ActionResult Index_Category()
        {
            var CategorysList = CategoryRepo.GetAllCategories();
            return View(CategorysList);
        }
        // GET: Category/Details
        public ActionResult Details_Caterory(string id)
        {
            var User = CategoryRepo.GetCategoryById(id);
            if (User == null)
            {
                return HttpNotFound();
            }
            return View(User);
        }
        // GET: Category/Create
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryRepo.CreateCategory(category);
                    return RedirectToAction("Index_Category", "Home");
                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult DeleteCategory(string id)
        {
            var category = CategoryRepo.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult DeleteCategory_Confirmed(string id)
        {
            try
            {
                CategoryRepo.DeleteCategory(id);
                return RedirectToAction("Index_Category", "Home");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult EditCategory(string id)
        {
            var category = CategoryRepo.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCategory(string id, Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryRepo.UpdateCategory(id, category);
                    return RedirectToAction("Index_Category", "Home");
                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }


        public ActionResult about()
        {
            return View();
        }
        public ActionResult blog_single()
        {
            return View();
        }

        public ActionResult blog()
        {
            return View();
        }

        public ActionResult cart()
        {
            return View();
        }

        public ActionResult checkout()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }

        public ActionResult menu()
        {
            return View();
        }

        public ActionResult product_single()
        {
            return View();
        }

        public ActionResult services()
        {
            return View();
        }

        public ActionResult shop()
        {
            return View();
        }
        public ActionResult index()
        {
            return View();
        }
    }
}