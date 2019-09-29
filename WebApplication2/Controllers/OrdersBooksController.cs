using AutoMapper;
using BussinessLayer.BO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class OrdersBooksController : Controller
    {
        #region    До разделениия проекта на слои

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

        //WebApplication2.UnitOfWork.UnitOfWork unitOfWork;
        //public OrdersBooksController()
        //{
        //    unitOfWork = new UnitOfWork.UnitOfWork();
        //}

        //public ActionResult Index()
        //{
        //    var model = unitOfWork.OrderBookUoWRepository.GetAll();
        //    return View(model);
        //}

        //public ActionResult CreateAndEdit(int? id)
        //{
        //    var books = unitOfWork.BookUoWRepository.GetAll();
        //    var users = unitOfWork.UserUoWRepository.GetAll();  
        //    ViewBag.Books = new SelectList(books, "Id", "Title");
        //    ViewBag.Users = new SelectList(users, "Id", "FIO");

        //    OrdersBooks model = unitOfWork.OrderBookUoWRepository.Get(id);
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult CreateAndEdit(OrdersBooks ordersBooks)
        //{

        //    var books = unitOfWork.BookUoWRepository.GetAll();
        //    var users = unitOfWork.UserUoWRepository.GetAll();

        //    if (ordersBooks.Deadline == null || ordersBooks.Deadline < DateTime.Now)
        //    {
        //        ViewBag.Books = new SelectList(books, "Id", "Title", ordersBooks.BookId);
        //        ViewBag.Users = new SelectList(users, "Id", "FIO", ordersBooks.UserId);
        //        ViewBag.Error = "Дата сдачи книга не может быть пустой или быть меньше текущей даты";
        //        return View(ordersBooks);
        //    }

        //    if (ordersBooks.Id == 0)
        //    {
        //        ordersBooks.CurentDate = DateTime.Now;
        //        ordersBooks.CurentDate.ToShortDateString();
        //        unitOfWork.OrderBookUoWRepository.Add(ordersBooks);
        //    }
        //    else
        //    {
        //        unitOfWork.OrderBookUoWRepository.Update(ordersBooks);
        //    }
        //    unitOfWork.OrderBookUoWRepository.Save();

        //    return RedirectToActionPermanent("Index", "OrdersBooks");
        //}

        //public ActionResult Delete(int id)
        //{
        //    unitOfWork.OrderBookUoWRepository.Delete(id);
        //    unitOfWork.OrderBookUoWRepository.Save();

        //    return RedirectToActionPermanent("Index", "OrdersBooks");
        //}

        //public ActionResult SendNotification(int userId)
        //{
        //    Users user = unitOfWork.UserUoWRepository.Get(userId);

        //    MailAddress fromWhom = new MailAddress("natali13_96@mail.ru", "Верните книгу!");
        //    MailAddress toWhom = new MailAddress(user.EmailUser);
        //    MailMessage message = new MailMessage(fromWhom, toWhom);
        //    message.Subject = "Верните книгу!";
        //    message.Body = string.Format("Уважаемый " + user.FIO + " верните книгу!");
        //    message.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
        //    smtp.Credentials = new NetworkCredential("natali13_96@mail.ru", "150596natalya.96N");
        //    smtp.EnableSsl = true;
        //    smtp.Send(message);

        //    return RedirectToAction("Index");
        //}

        //public ActionResult DownloadListDebtors()
        //{
        //    List<OrdersBooks> listDebtors = unitOfWork.OrderBookUoWRepository.GetAll().Where(i => i.Deadline < DateTime.Now).ToList();

        //    StringBuilder sb = new StringBuilder();
        //    string header = "№\t User\t Book\t Deadline";
        //    sb.Append(header);
        //    sb.Append("\r\n\r\n");
        //    sb.Append('-', header.Length * 2);
        //    sb.Append("\r\n\r\n");
        //    foreach (var item in listDebtors)
        //    {
        //        sb.Append((listDebtors.IndexOf(item) + 1) + "\t " + item.UserId + "\t " + item.BookId + "\t " + item.Deadline.Date + "\r\n");
        //    }
        //    byte[] data = Encoding.ASCII.GetBytes(sb.ToString());

        //    string contentType = "text/plain";
        //    return File(data, contentType, "listDebtors.txt");
        //}

        #endregion

        #endregion

        #region После разделения на слои
        protected IMapper mapper;

        public OrdersBooksController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var orderBookBO = DependencyResolver.Current.GetService<OrderBookBO>().GetOrdersBooksList();
            var userBO = DependencyResolver.Current.GetService<UserBO>().GetUsersList();
            var bookBO = DependencyResolver.Current.GetService<BookBO>().GetBooksList();

            ViewBag.OrdersBooks = orderBookBO.Select(m => mapper.Map<OrderBookViewModel>(m)).ToList();
            ViewBag.Users = userBO.Select(m => mapper.Map<UserViewModel>(m)).ToList();
            ViewBag.Books = bookBO.Select(m => mapper.Map<BookViewModel>(m)).ToList();

            return View();
        }

        public ActionResult CreateAndEdit(int? id)
        {
            var userBO = DependencyResolver.Current.GetService<UserBO>();
            var bookBO = DependencyResolver.Current.GetService<BookBO>();

            var orderBookBO = DependencyResolver.Current.GetService<OrderBookBO>();
            var ordersBooksModel = mapper.Map<OrderBookViewModel>(orderBookBO);

            if (id == null)
            {
                ViewBag.Header = "Создание заказа";  
            }
            else
            {
                var orderBOList = orderBookBO.GetOrderBookById(id);
                ordersBooksModel = mapper.Map<OrderBookViewModel>(orderBOList);
                ViewBag.Header = "Редактирование заказа";
            }

            ViewBag.Users = new SelectList(userBO.GetUsersList().Select(m => mapper.Map<UserViewModel>(m)).ToList(), "Id", "FIO");
            ViewBag.Books = new SelectList(bookBO.GetBooksList().Select(m => mapper.Map<BookViewModel>(m)).ToList(), "Id", "Title");

            return View(ordersBooksModel);
        }

        [HttpPost]
        public ActionResult CreateAndEdit(OrderBookViewModel ordersBooksModel)
        {
            var orderBO = mapper.Map<OrderBookBO>(ordersBooksModel);    
            
            if (ModelState.IsValid)
            {      
                orderBO.Save();   
                return RedirectToActionPermanent("Index", "OrdersBooks");
            }
            else
            {
                return View(ordersBooksModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var orderBO = DependencyResolver.Current.GetService<OrderBookBO>().GetOrderBookById(id);
            orderBO.Delete(id);

            return RedirectToActionPermanent("Index", "OrdersBooks");
        }

        public ActionResult SendNotification(int id)
        {   
            var orderBO = DependencyResolver.Current.GetService<OrderBookBO>().GetOrderBookById(id);
            var order = mapper.Map<OrderBookViewModel>(orderBO);
            var userBO = DependencyResolver.Current.GetService<UserBO>().GetUserById(order.UserId);
            var user = mapper.Map<UserViewModel>(userBO);
            var bookBO = DependencyResolver.Current.GetService<BookBO>().GetBookById(order.BookId);
            var book = mapper.Map<BookViewModel>(bookBO);

            MailAddress from = new MailAddress("natali13_96@mail.ru", "Верните книгу!");
            MailAddress to = new MailAddress(user.EmailUser);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Верните книгу!";
            message.Body = string.Format("Уважаемый " + user.FIO + ", Вы просрочили дату сдачи книги " + book.Title + ". Верните книгу!");
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential("natali13_96@mail.ru", "150596natalya.96N");
            smtp.EnableSsl = true;
            smtp.Send(message);

            return RedirectToActionPermanent("Index", "OrdersBooks");
        }

        public ActionResult DownloadListDebtors()
        {

            var orderBO = DependencyResolver.Current.GetService<OrderBookBO>().GetOrdersBooksList();
            var listDebtors = orderBO.Select(m => mapper.Map<OrderBookViewModel>(m)).Where(i => i.Deadline < DateTime.Now && i.ActualReturnDate == i.CurentDate).ToList();
            StringBuilder sb = new StringBuilder();
            string header = "№\t User\t Book\t Deadline";
            sb.Append(header);
            sb.Append("\r\n\r\n");
            sb.Append('-', header.Length * 2);
            sb.Append("\r\n\r\n");
            foreach (var item in listDebtors)
            {
                sb.Append((listDebtors.IndexOf(item) + 1) + "\t " + item.UserId + "\t " + item.BookId + "\t " + item.Deadline.Date + "\r\n");
            }
            byte[] data = Encoding.ASCII.GetBytes(sb.ToString());

            string contentType = "text/plain";
            return File(data, contentType, "listDebtors.txt");


            //List<OrderBookViewModel> deadlines = new List<OrderBookViewModel>();

            //var orderBO = DependencyResolver.Current.GetService<OrderBookBO>().GetOrdersBooksList();
            //var userBO = DependencyResolver.Current.GetService<UserBO>();

            //var links = orderBO.Select(m => mapper.Map<OrderBookViewModel>(m)).Where(o => o.CurentDate == o.ActualReturnDate && DateTime.Today > o.Deadline).ToList();
            //string path = @"C:\Test\deadline.txt";

            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //{
            //    using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
            //    {
            //        foreach (var item in deadlines)
            //        {
            //            var user = mapper.Map<UserViewModel>(userBO.GetUserById(item.UserId));
            //            string fio = user.FIO;
            //            sw.WriteLine($"User: {fio}   CurentDate: {item.CurentDate}  Deadline: {item.Deadline}");
            //        }
            //    }
            //}

            #region MemoryStream
            //    //byte[] data = new byte[5000];
            //    //MemoryStream ms = new MemoryStream(data);
            //    //StreamWriter sw = new StreamWriter(ms);

            //    //foreach (var item in links)
            //    //    if (item.Deadline < DateTime.Now)
            //    //    {
            //    //        string fio = db.Users.Where(u => u.Id == item.UserId).FirstOrDefault().FIO;
            //    //        sw.WriteLine($"User: {fio}   CreationDate: {item.CreationDate}  Deadline: {item.Deadline}");
            //    //    }
            //    //sw.Flush();
            //    //sw.Close();
            //    ////sr.Close();
            //    //string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //    //FileStream file = new FileStream($@"{dir}\test.txt", FileMode.OpenOrCreate);
            //    //ms.CopyTo(file);
            //    ////return File(ms, "text/plain");
            #endregion

            //return RedirectToActionPermanent("Index", "OrdersBooks");

            #endregion
        }
    }
}