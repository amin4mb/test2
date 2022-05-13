using Microsoft.AspNetCore.Mvc;
using test2.Models;
using test2_.Entit;

namespace test2_.Controllers
{
    public class ProductController : Controller
    {
        ProductDb ProductDB = new ProductDb();


        public IActionResult product()
        {
            var x = ProductDB.GetProducts();
            return View(x);
        }
        public IActionResult Get( int id)
        {

            var x = ProductDB.Get(id);
            return View(x);

        }


        public IActionResult Details(int id)
        {
            //ViewBag.lists = ProductDB.GetUsers(id).Name;
            var us = ProductDB.GetUC(id);


            var product = ProductDB.Get(id);             
            var xx = new editttt { product = product, uc = us };
            return View(xx);
        }

        public IActionResult Edit(int id)
        {
            var p = ProductDB.Get(id);
            ViewBag.namee = ProductDB.cat();

            return View(p);
        }
        [HttpPost]
        public IActionResult Edit(Product Product)
        {

            ProductDB.Edit(Product);

            return RedirectToAction("product");

        }
        public IActionResult Delete(int id)
        {
             ProductDB.Delete(id);

            return RedirectToAction("product");

        }



        public IActionResult create()
        {
            //var c = ProductDB.GetCategori();
            //ViewBag.name = c.Select(x =>x.Name);
            ViewBag.name = ProductDB.cat();

            return View();

        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            ProductDB.Add(p);
            return RedirectToAction("product");
        }
    }
}
