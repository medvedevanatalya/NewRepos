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
    public class AuthorController : Controller
    {
        #region   До разделения на слои

        #region        До добавления UnitOfWork
        //    // GET: Author
        //    public ActionResult Index()
        //    {
        //        List<Authors> authors;

        //        List<Authors> authorsTop = new List<Authors>();

        //        using (Model1 db = new Model1())
        //        {
        //            authors = db.Authors.ToList();  

        //            //ТОП 5 АВТОРОВ
        //            var expensiveBooks = db.Books.OrderByDescending(b => b.Price).Select(b => b.AuthorId).Distinct().Take(5).ToList(); //топ 5 авторов
        //            expensiveBooks.ForEach(
        //              x =>
        //              {
        //                  authorsTop.Add(db.Authors.Where(a => a.Id == x).FirstOrDefault());
        //              });
        //            ViewBag.AuthorsList = authorsTop;   

        //        }
        //        return View(authors) ;
        //    }


        //    #region Views Create и Edit отдельно 
        //    //public ActionResult Create()
        //    //{
        //    //    return View();
        //    //}

        //    //[HttpPost]
        //    //public ActionResult Create(Authors author)
        //    //{
        //    //    using (Model1 db = new Model1())
        //    //    {
        //    //        db.Authors.Add(author);
        //    //        db.SaveChanges();
        //    //    }
        //    //    return Redirect("Index");
        //    //}

        //    //public ActionResult Edit(int? id)
        //    //{
        //    //    Authors author;
        //    //    using (Model1 db = new Model1())
        //    //    {
        //    //        author = db.Authors.Where(a => a.Id == id).FirstOrDefault();
        //    //    }
        //    //    return View(author);
        //    //}

        //    //[HttpPost]
        //    //public ActionResult Edit(Authors author)
        //    //{
        //    //    using (Model1 db = new Model1())
        //    //    {
        //    //        var oldAuthor = db.Authors.Where(a => a.Id == author.Id).FirstOrDefault();
        //    //        oldAuthor.FirstName = author.FirstName;
        //    //        oldAuthor.LastName = author.LastName;

        //    //        db.SaveChanges();
        //    //    }
        //    //    return RedirectToActionPermanent("Index", "Author");
        //    //}
        //    #endregion

        //    public ActionResult CreateAndEdit(int? id)
        //    {
        //        Authors author;
        //        using (Model1 db = new Model1())
        //        {
        //            author = db.Authors.Where(a => a.Id == id).FirstOrDefault();
        //        }
        //        return View(author);
        //    }

        //    [HttpPost]
        //    public ActionResult CreateAndEdit(Authors author)
        //    {
        //        using (Model1 db = new Model1())
        //        {
        //            if(author.Id==0)
        //            {
        //                Authors newAuthor = new Authors() { FirstName = author.FirstName, LastName = author.LastName };
        //                db.Authors.Add(newAuthor);
        //            }
        //            else
        //            {
        //                Authors oldAuthor = db.Authors.Where(a => a.Id == author.Id).FirstOrDefault();

        //                oldAuthor.FirstName = author.FirstName;
        //                oldAuthor.LastName = author.LastName;
        //            } 
        //            db.SaveChanges();
        //        }
        //        return RedirectToActionPermanent("Index", "Author");
        //    }

        //    public ActionResult Delete(int id)
        //    {
        //        using (Model1 db = new Model1())
        //        {
        //            var author = db.Authors.Where(a => a.Id == id).FirstOrDefault();
        //            db.Authors.Remove(author);
        //            db.SaveChanges();
        //        }
        //        return RedirectToAction("Index", "Author");
        //    }

        //    public ActionResult MyPartialView()
        //    {
        //        return PartialView();
        //    }
        #endregion

        #region После добавления UnitOfWork

        //WebApplication2.UnitOfWork.UnitOfWork unitOfWork;
        //public AuthorController()
        //{
        //    unitOfWork = new UnitOfWork.UnitOfWork();
        //}

        //public ActionResult Index()
        //{
        //    IEnumerable<Authors> model = unitOfWork.AuthorUoWRepository.GetAll();
        //    return View(model);
        //}

        //public ActionResult CreateAndEdit(int? id)
        //{
        //    Authors model = unitOfWork.AuthorUoWRepository.Get(id);
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult CreateAndEdit(Authors author)
        //{
        //    if (author.Id == 0)
        //    {
        //        unitOfWork.AuthorUoWRepository.Add(author);
        //    }
        //    else
        //    {
        //        unitOfWork.AuthorUoWRepository.Update(author);
        //    }
        //    unitOfWork.AuthorUoWRepository.Save();

        //    return RedirectToActionPermanent("Index", "Author");
        //}

        //public ActionResult Delete(int id)
        //{
        //    unitOfWork.AuthorUoWRepository.Delete(id);
        //    unitOfWork.AuthorUoWRepository.Save();

        //    return RedirectToActionPermanent("Index", "Author");
        //}

        #endregion

        #endregion


        #region После разделения на слои   

        protected IMapper mapper;

        public AuthorController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ActionResult Index()
        {   
            var authorBO = DependencyResolver.Current.GetService<AuthorBO>();
            var authorList = authorBO.GetAuthorsList().OrderBy(n => n.LastName); //сортировка по фамилии в алфавитном порядке 
            ViewBag.Authors = authorList.Select(a => mapper.Map<AuthorViewModel>(a)).ToList();

            List<AuthorViewModel> authorsTop = new List<AuthorViewModel>();
            BookBO booksBO = DependencyResolver.Current.GetService<BookBO>(); 

            //топ 5 авторов
            var expensiveBooks = booksBO.GetBooksList().OrderByDescending(b => b.Price).Select(x => mapper.Map<BookViewModel>(x)).ToList();

            expensiveBooks.ForEach(
                x =>
                {
                    authorsTop.Add(authorList.Select(m=>mapper.Map<AuthorViewModel>(m)).Where(a => a.Id == x.AuthorId).FirstOrDefault());
                });
            ViewBag.ListTopAuthors = authorsTop.Distinct().Take(5);       

            return View();
        }

        public ActionResult CreateAndEdit(int? id)
        {
            var authorBO = DependencyResolver.Current.GetService<AuthorBO>();
            var authorsModel = mapper.Map<AuthorViewModel>(authorBO);

            if (id == null)
            {
                ViewBag.Header = "Создание автора";    
            }
            else
            {
                var authorBOList = authorBO.GetAuthorById(id);
                authorsModel = mapper.Map<AuthorViewModel>(authorBOList);
                ViewBag.Header = "Редактирование автора"; 
            }

            return View(authorsModel);
        }

        [HttpPost]
        public ActionResult CreateAndEdit(AuthorViewModel authorsModel)
        {
            var authorBO = mapper.Map<AuthorBO>(authorsModel);
            if (ModelState.IsValid)
            {
                authorBO.Save();
                return RedirectToActionPermanent("Index", "Author");
            }
            else
            {
                return View(authorsModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var author = DependencyResolver.Current.GetService<AuthorBO>().GetAuthorById(id);
            author.Delete(id);

            return RedirectToActionPermanent("Index", "Author");
        }

        public ActionResult _MyPartialView()
        {         
            return PartialView();
        }
        #endregion
    }
}