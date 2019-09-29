using AutoMapper;
using BussinessLayer.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        #region    До разделениия проекта на слои   

        #region        До добавления UnitOfWork
        //// GET: User
        //public ActionResult Index()
        //{
        //    List<Users> users;
        //    using (Model1 db = new Model1())
        //    {
        //        users = db.Users.ToList();
        //    }
        //    return View(users);
        //}

        //#region Views Create Edit
        ////public ActionResult Create()
        ////{
        ////    return View();
        ////}

        ////[HttpPost]
        ////public ActionResult Create(Users user)
        ////{
        ////    using (Model1 db = new Model1())
        ////    {
        ////        db.Users.Add(user);
        ////        db.SaveChanges();
        ////    }
        ////    return Redirect("Index");
        ////}

        ////public ActionResult Edit(int? id)
        ////{
        ////    Users user;
        ////    List<OrdersBooks> userOrderHistory = new List<OrdersBooks>();

        ////    using (Model1 db = new Model1())
        ////    {
        ////        user = db.Users.Where(u => u.Id == id).FirstOrDefault();

        ////       // История заказов пользователя, последние 5 записей
        ////        var userOrders = db.OrdersBooks.OrderByDescending(d => d.CurentDate).Select(o => o.Id).Take(5).ToList();
        ////        userOrders.ForEach(
        ////          x =>
        ////                  {
        ////                      userOrderHistory.Add(db.OrdersBooks.Where(a => a.Id == x).FirstOrDefault());
        ////                  });
        ////        ViewBag.UserOrderHistory = userOrderHistory;
        ////    }
        ////    return View(user);
        ////}

        ////[HttpPost]
        ////public ActionResult Edit(Users user)
        ////{
        ////    using (Model1 db = new Model1())
        ////    {       
        ////        var oldUser = db.Users.Where(u => u.Id == user.Id).FirstOrDefault();
        ////        oldUser.FIO = user.FIO;
        ////        oldUser.EmailUser = user.EmailUser;

        ////        db.SaveChanges();         
        ////    }
        ////    return RedirectToActionPermanent("Index", "User");
        ////}
        //#endregion


        //public ActionResult CreateAndEdit(int? id)
        //{
        //    Users user;
        //    List<OrdersBooks> userOrderHistory = new List<OrdersBooks>();

        //    using (Model1 db = new Model1())
        //    {
        //        user = db.Users.Where(u => u.Id == id).FirstOrDefault();

        //        ////История заказов пользователя, последние 5 записей     
        //        //var userOrders = db.OrdersBooks.OrderByDescending(d => d.CurentDate).Where(u => u.UserId == user.Id).Select(o => o.Id).Take(5).ToList();
        //        //userOrders.ForEach(
        //        //  x =>
        //        //  {
        //        //      userOrderHistory.Add(db.OrdersBooks.Where(a => a.Id == x).FirstOrDefault());
        //        //  });
        //        //ViewBag.UserOrderHistory = userOrderHistory;  
        //    }
        //    return View(user);
        //}   

        //[HttpPost]
        //public ActionResult CreateAndEdit(Users user)
        //{
        //    using (Model1 db = new Model1())
        //    {
        //        if(user.Id==0)
        //        {
        //            Users newUser = new Users() { FIO = user.FIO, EmailUser = user.EmailUser };
        //            db.Users.Add(newUser);
        //        }
        //        else
        //        {
        //            Users oldUser = db.Users.Where(u => u.Id == user.Id).FirstOrDefault();
        //            oldUser.FIO = user.FIO;
        //            oldUser.EmailUser = user.EmailUser;
        //        }      
        //        db.SaveChanges();
        //    }
        //    return RedirectToActionPermanent("Index", "User");
        //}

        //public ActionResult Delete(int id)
        //{
        //    using (Model1 db = new Model1())
        //    {
        //        var user = db.Users.Where(u => u.Id == id).FirstOrDefault();
        //        db.Users.Remove(user);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index", "User");
        //}

        ////public ActionResult UserStory()
        ////{
        ////    return PartialView();
        ////}

    #endregion

    #region После добавления UnitOfWork

    //WebApplication2.UnitOfWork.UnitOfWork unitOfWork;

    //public UserController()
    //{
    //    unitOfWork = new UnitOfWork.UnitOfWork();
    //}

    //public ActionResult Index()
    //{
    //    var model = unitOfWork.UserUoWRepository.GetAll();
    //    return View(model);
    //}

    //public ActionResult CreateAndEdit(int? id)
    //{
    //    Users model = unitOfWork.UserUoWRepository.Get(id);
    //    return View(model);
    //}

    //[HttpPost]
    //public ActionResult CreateAndEdit(Users user)
    //{
    //    if (user.Id == 0)
    //    {
    //        unitOfWork.UserUoWRepository.Add(user);
    //    }
    //    else
    //    {
    //        unitOfWork.UserUoWRepository.Update(user);
    //    }
    //    unitOfWork.UserUoWRepository.Save();

    //    return RedirectToActionPermanent("Index", "User");
    //}

    //public ActionResult Delete(int id)
    //{
    //    unitOfWork.UserUoWRepository.Delete(id);
    //    unitOfWork.UserUoWRepository.Save();

    //    return RedirectToActionPermanent("Index", "User");
    //}

    #endregion

    #endregion


    #region После разделения на слои
    protected IMapper mapper;

        public UserController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var userBO = DependencyResolver.Current.GetService<UserBO>();
            var userList = userBO.GetUsersList();
            ViewBag.Users = userList.Select(m => mapper.Map<UserViewModel>(m)).ToList();

            return View();
        }

        public ActionResult CreateAndEdit(int? id)
        {
            var userBO = DependencyResolver.Current.GetService<UserBO>();
            var usersModel = mapper.Map<UserViewModel>(userBO);
            if (id == null)
            {
                ViewBag.Header = "Создание пользователя";    
            }
            else
            {
                ViewBag.Header = "Редактирование пользователя";

                var user = userBO.GetUserById(id);
                usersModel = mapper.Map<UserViewModel>(user);

                //История заказов пользователя, последние 5 записей   
                var bookBO = DependencyResolver.Current.GetService<BookBO>().GetBooksList();

                var orderBookBO = DependencyResolver.Current.GetService<OrderBookBO>();
                var orderBookUser = orderBookBO.GetOrdersBooksList().Where(o => o.UserId == id).ToList();

                ViewBag.UserOrderHistory = orderBookUser.Select(m => mapper.Map<OrderBookViewModel>(m)).ToList().Take(5);
                ViewBag.Books = bookBO.Select(m => mapper.Map<BookViewModel>(m)).ToList();
            }
            return View(usersModel);
        }

        [HttpPost]
        public ActionResult CreateAndEdit(UserViewModel usersModel)
        {
            var userBO = mapper.Map<UserBO>(usersModel);
            if (ModelState.IsValid)
            {
                userBO.Save();  
                return RedirectToActionPermanent("Index", "User");
            }
            else
            {
                return View(usersModel);    
            }
        }

        public ActionResult Delete(int id)
        {
            var user = DependencyResolver.Current.GetService<UserBO>().GetUserById(id);
            user.Delete(id);

            return RedirectToActionPermanent("Index", "User");
        }

        public ActionResult UserOrderHistory()
        {
            return PartialView();
        }

        #endregion
    }
}