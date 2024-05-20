using Bogus;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models.Products;
using WebApplication.Models.Services;

namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductDAO productsDAO = new ProductDAO();
            return View(productsDAO.GetAllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            ProductDAO products = new ProductDAO();

            List<ProductViewModel> productList = products.SearchProducts(searchTerm);

            return View("index", productList);
        }

        public IActionResult SearchForm()
        {
           return View();
        }

        public IActionResult InputForm()
        {
            return View();
        }

        public IActionResult ProcessCreate(ProductViewModel product)
        {
            ProductDAO products = new ProductDAO();
            products.Insert(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult ShowDetails(int id)
        {
            ProductDAO products = new ProductDAO();
            ProductViewModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }

        public IActionResult Edit(int id)
        {
            ProductDAO products = new ProductDAO();
            ProductViewModel foundProduct = products.GetProductById(id);
            return View("ShowEdit",foundProduct);
        }


        public IActionResult ProcessEdit(ProductViewModel product)
        {
            ProductDAO products = new ProductDAO();
            products.Update(product);
            return View("Index", products.GetAllProducts());
        }

        public IActionResult Delete(int id)
        {
            ProductDAO products = new ProductDAO();
            ProductViewModel product = products.GetProductById(id);
            products.Delete(product);
            return View("Index", products.GetAllProducts());
        }


        public IActionResult Message()
        {
            return View("message");
        }
        public IActionResult Welcome(string name, int secretNumebr = 13)
        {
            ViewBag.Name = name;
            ViewBag.Secret = secretNumebr;
            return View();
        }
    }
}
