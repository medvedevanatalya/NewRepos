using System;
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
        #region        До добавления UnitOfWork
        ////// GET: OrdersBooks
        ////public ActionResult Index()
        ////{
        ////    List<OrdersBooks> ordersBooks;
        ////    using (Model1 db = new Model1())
        ////    {
        ////        ordersBooks = db.OrdersBooks.ToList();
        ////    }
        ////    return View(ordersBooks);
        ////}

        ////#region Views Create Edit
        //////public ActionResult Create()
        //////{            
        //////    return View();
        //////}

        //////[HttpPost]
        //////public ActionResult Create(OrdersBooks orderBook)
        //////{
        //////    using (Model1 db = new Model1())
        //////    {
        //////        orderBook.CurentDate = DateTime.Now;
        //////        orderBook.CurentDate.ToShortDateString();

        //////        db.OrdersBooks.Add(orderBook);
        //////        db.SaveChanges();
        //////    }
        //////    return Redirect("Index");
        //////}

        //////public ActionResult Edit(int? id)
        //////{
        //////    OrdersBooks orderBook;
        //////    using (Model1 db = new Model1())
        //////    {
        //////        orderBook = db.OrdersBooks.Where(a => a.Id == id).FirstOrDefault();
        //////    }
        //////    return View(orderBook);
        //////}

        //////[HttpPost]
        //////public ActionResult Edit(OrdersBooks orderBook)
        //////{
        //////    using (Model1 db = new Model1())
        //////    {
        //////        var oldOrderBook = db.OrdersBooks.Where(a => a.Id == orderBook.Id).FirstOrDefault();
        //////        oldOrderBook.UserId = orderBook.UserId;
        //////        oldOrderBook.BookId = orderBook.BookId;

        //////        //oldOrderBook.CurentDate = DateTime.Now;
        //////        //oldOrderBook.CurentDate.ToShortDateString();

        //////        oldOrderBook.Deadline = orderBook.Deadline;
        //////        oldOrderBook.Deadline.ToShortDateString();

        //////        oldOrderBook.ActualReturnDate = orderBook.ActualReturnDate;
        //////        oldOrderBook.ActualReturnDate.ToShortDateString();

        //////        db.SaveChanges();
        //////    }
        //////    return RedirectToActionPermanent("Index", "OrdersBooks");
        //////}
        ////#endregion


        ////public ActionResult CreateAndEdit(int? id)
        ////{
        ////    OrdersBooks orderBook;
        ////    List<Books> books;
        ////    List<Users> users;

        ////    using (Model1 db = new Model1())
        ////    {
        ////        books = db.Books.ToList();
        ////        users = db.Users.ToList();

        ////        ViewBag.Books = new SelectList(books, "Id", "Title");
        ////        ViewBag.Users = new SelectList(users, "Id", "FIO");

        ////        orderBook = db.OrdersBooks.Where(a => a.Id == id).FirstOrDefault();
        ////    }
        ////    return View(orderBook);     
        ////}

        ////[HttpPost]
        ////public ActionResult CreateAndEdit(OrdersBooks orderBook)
        ////{
        ////    using (Model1 db = new Model1())
        ////    {
        ////        List<Books> books = db.Books.ToList();
        ////        List<Users> users = db.Users.ToList();

        ////        if (orderBook.Deadline == null || orderBook.Deadline < DateTime.Now)
        ////        {
        ////            ViewBag.Books = new SelectList(books, "Id", "Title", orderBook.BookId);
        ////            ViewBag.Users = new SelectList(users, "Id", "FIO", orderBook.UserId);
        ////            ViewBag.Error = "Дата сдачи книга не может быть пустой или быть меньше текущей даты";
        ////            return View(orderBook);
        ////        }


        ////        if (orderBook.Id == 0)
        ////        {
        ////            orderBook.CurentDate = DateTime.Now;
        ////            orderBook.CurentDate.ToShortDateString();

        ////            OrdersBooks newOrderBook = new OrdersBooks() { UserId = orderBook.UserId, BookId = orderBook.BookId, CurentDate = orderBook.CurentDate, Deadline = orderBook.Deadline, ActualReturnDate = orderBook.ActualReturnDate };

        ////            db.OrdersBooks.Add(newOrderBook);
        ////        }
        ////        else
        ////        {
        ////            OrdersBooks oldOrderBook = db.OrdersBooks.Where(a => a.Id == orderBook.Id).FirstOrDefault();

        ////            oldOrderBook.UserId = orderBook.UserId;
        ////            oldOrderBook.BookId = orderBook.BookId;

        ////            oldOrderBook.Deadline = orderBook.Deadline;
        ////            oldOrderBook.Deadline.ToShortDateString();

        ////            oldOrderBook.ActualReturnDate = orderBook.ActualReturnDate;
        ////            oldOrderBook.ActualReturnDate.ToShortDateString();
        ////        }
        ////        db.SaveChanges();   
        ////    }
        ////    return RedirectToActionPermanent("Index", "OrdersBooks");  
        ////}

        ////public ActionResult Delete(int id)
        ////{
        ////    using (Model1 db = new Model1())
        ////    {
        ////        var orderBook = db.OrdersBooks.Where(a => a.Id == id).FirstOrDefault();
        ////        db.OrdersBooks.Remove(orderBook);
        ////        db.SaveChanges();
        ////    }
        ////    return RedirectToAction("Index", "OrdersBooks");
        ////} 

        ////public ActionResult SendNotification(int userId)
        ////{    
        ////    Users user;
        ////    using (Model1 db = new Model1())
        ////    {
        ////        user = db.Users.Where(us => us.Id == (int)userId).FirstOrDefault();
        ////    }

        ////    MailAddress fromWhom = new MailAddress("natali13_96@mail.ru", "Верните книгу!");
        ////    MailAddress toWhom = new MailAddress(user.EmailUser);
        ////    MailMessage message = new MailMessage(fromWhom, toWhom);
        ////    message.Subject = "Верните книгу!";
        ////    message.Body = string.Format("Уважаемый " + user.FIO + " верните книгу!");
        ////    message.IsBodyHtml = true;
        ////    SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
        ////    smtp.Credentials = new NetworkCredential("natali13_96@mail.ru", "150596natalya.96N");
        ////    smtp.EnableSsl = true;
        ////    smtp.Send(message);

        ////    return RedirectToAction("Index");
        ////}
        #endregion



        #region После добавления UnitOfWork

        WebApplication2.UnitOfWork.UnitOfWork unitOfWork;
        public OrdersBooksController()
        {
            unitOfWork = new UnitOfWork.UnitOfWork();
        }

        public ActionResult Index()
        {
            var model = unitOfWork.OrderBookUoWRepository.GetAll();
            return View(model);
        }

        public ActionResult CreateAndEdit(int? id)
        {
            OrdersBooks model = unitOfWork.OrderBookUoWRepository.Get(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateAndEdit(OrdersBooks ordersBooks)
        {
            if (ordersBooks.Id == 0)
            {
                unitOfWork.OrderBookUoWRepository.Add(ordersBooks);
            }
            else
            {
                unitOfWork.OrderBookUoWRepository.Update(ordersBooks);
            }
            unitOfWork.OrderBookUoWRepository.Save();

            return RedirectToActionPermanent("Index", "OrdersBooks");
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.OrderBookUoWRepository.Delete(id);
            unitOfWork.OrderBookUoWRepository.Save();

            return RedirectToActionPermanent("Index", "OrdersBooks");
        }

        #endregion
    }
}