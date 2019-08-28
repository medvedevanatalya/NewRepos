using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class UsersAndBooksController : Controller
    {
        // GET: UsersAndBooks
        public ActionResult Index()
        {
            List<UsersAndBooks> usersAndBooks;
            using (Model1 db = new Model1())
            {
                usersAndBooks = db.UsersAndBooks.ToList();
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsersAndBooks usersAndBooks)
        {
            using (Model1 db = new Model1())
            {
                db.UsersAndBooks.Add(usersAndBooks);
                db.SaveChanges();
            }
            return Redirect("Index");
        }
    }
}