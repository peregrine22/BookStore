using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private BookContext bookContext = new BookContext();
        private PurchaseContext purchaseContext = new PurchaseContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Books()
        {
            return View(bookContext.Books.ToList());
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            List<Book> books = bookContext.Books.ToList();
            Book selectedBook = new Book();
            foreach (var book in books)
            {
                if (book.Books_Id == id)
                {
                    selectedBook = book;
                }
            }
            ViewBag.Book = selectedBook;
            System.Diagnostics.Debug.Write("Buy get");
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            purchaseContext.Purchases.Add(purchase);
            System.Diagnostics.Debug.Write("Buy Post");
            return View("Thanks");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}