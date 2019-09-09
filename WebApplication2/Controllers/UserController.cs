using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<Users> users;
            using (Model1 db = new Model1())
            {
                users = db.Users.ToList();
            }
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Users user)
        {
            using (Model1 db = new Model1())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            return Redirect("Index");
        }

        public ActionResult Edit(int? id)
        {
            Users user;
            List<OrdersBooks> userOrderHistory = new List<OrdersBooks>();

            using (Model1 db = new Model1())
            {
                user = db.Users.Where(u => u.Id == id).FirstOrDefault();

                //История заказов пользователя, последние 5 записей     
                var userOrders = db.OrdersBooks.OrderByDescending(d => d.CurentDate).Select(o => o.Id).Take(5).ToList();
                userOrders.ForEach(
                  x =>
                  {
                      userOrderHistory.Add(db.OrdersBooks.Where(a => a.Id == x).FirstOrDefault());
                  });
                ViewBag.UserOrderHistory = userOrderHistory;
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(Users user)
        {
            using (Model1 db = new Model1())
            {       
                var oldUser = db.Users.Where(u => u.Id == user.Id).FirstOrDefault();
                oldUser.FIO = user.FIO;
                oldUser.EmailUser = user.EmailUser;

                db.SaveChanges();         
            }
            return RedirectToActionPermanent("Index", "User");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "User");
        }

        public ActionResult UserStory()
        {
            return PartialView();
        }
    }
}