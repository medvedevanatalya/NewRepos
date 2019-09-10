﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class OrdersBooksController : Controller
    {
        // GET: OrdersBooks
        public ActionResult Index()
        {
            List<OrdersBooks> ordersBooks;
            using (Model1 db = new Model1())
            {
                ordersBooks = db.OrdersBooks.ToList();      
            }
            return View(ordersBooks);
        }

        public ActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrdersBooks orderBook)
        {
            using (Model1 db = new Model1())
            {
                orderBook.CurentDate = DateTime.Now;
                orderBook.CurentDate.ToShortDateString();
                  
                db.OrdersBooks.Add(orderBook);
                db.SaveChanges();
            }
            return Redirect("Index");
        }

        public ActionResult Edit(int? id)
        {
            OrdersBooks orderBook;
            using (Model1 db = new Model1())
            {
                orderBook = db.OrdersBooks.Where(a => a.Id == id).FirstOrDefault();
            }
            return View(orderBook);
        }

        [HttpPost]
        public ActionResult Edit(OrdersBooks orderBook)
        {
            using (Model1 db = new Model1())
            {
                var oldOrderBook = db.OrdersBooks.Where(a => a.Id == orderBook.Id).FirstOrDefault();
                oldOrderBook.UserId = orderBook.UserId;
                oldOrderBook.BookId = orderBook.BookId;

                //oldOrderBook.CurentDate = DateTime.Now;
                //oldOrderBook.CurentDate.ToShortDateString();

                oldOrderBook.Deadline = orderBook.Deadline;
                oldOrderBook.Deadline.ToShortDateString();

                oldOrderBook.ActualReturnDate = orderBook.ActualReturnDate;
                oldOrderBook.ActualReturnDate.ToShortDateString();

                db.SaveChanges();
            }
            return RedirectToActionPermanent("Index", "OrdersBooks");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var orderBook = db.OrdersBooks.Where(a => a.Id == id).FirstOrDefault();
                db.OrdersBooks.Remove(orderBook);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "OrdersBooks");
        }

        public ActionResult SendNotification(int userId)
        {    
            Users user;
            using (Model1 db = new Model1())
            {
                user = db.Users.Where(us => us.Id == (int)userId).FirstOrDefault();
            }

            MailAddress fromWhom = new MailAddress("natali13_96@mail.ru", "Верните книгу!");
            MailAddress toWhom = new MailAddress(user.EmailUser);
            MailMessage message = new MailMessage(fromWhom, toWhom);
            message.Subject = "Верните книгу!";
            message.Body = string.Format("Уважаемый " + user.FIO + " верните книгу!");
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential("natali13_96@mail.ru", "150596natalya.96N");
            smtp.EnableSsl = true;
            smtp.Send(message);

            return RedirectToAction("Index");
        }
    }
}