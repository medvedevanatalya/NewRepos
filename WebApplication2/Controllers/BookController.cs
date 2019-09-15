using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<Books> books;
            using (Model1 db = new Model1())
            {
                books = db.Books.ToList();
            }
            return View(books);
        }


        #region Views Create Edit
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Books book)
        //{
        //    using (Model1 db = new Model1())
        //    {
        //        db.Books.Add(book);
        //        db.SaveChanges();
        //    }
        //    return Redirect("Index");
        //}

        //public ActionResult Edit(int? id)
        //{
        //    Books book;
        //    using (Model1 db = new Model1())
        //    {
        //        book = db.Books.Where(a => a.Id == id).FirstOrDefault();
        //    }
        //    return View(book);
        //}

        //[HttpPost]
        //public ActionResult Edit(Books book)
        //{
        //    using (Model1 db = new Model1())
        //    {
        //        var oldBook = db.Books.Where(a => a.Id == book.Id).FirstOrDefault();
        //        oldBook.AuthorId = book.AuthorId;
        //        oldBook.Title = book.Title;
        //        oldBook.Pages = book.Pages;
        //        oldBook.Price = book.Price;

        //        db.SaveChanges();
        //    }
        //    return RedirectToActionPermanent("Index", "Book");
        //}
        #endregion
                
        public ActionResult CreateAndEdit(int? id)
        {
            Books book;
            List<Authors> authors;   

            using (Model1 db = new Model1())
            {
                authors = db.Authors.ToList();
                ViewBag.Authors = new SelectList(authors, "Id", "FirstName");
                book = db.Books.Where(a => a.Id == id).FirstOrDefault();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult CreateAndEdit(Books book)
        {
            using (Model1 db = new Model1())
            {
                if(book.Id==0)
                {
                    Books newBook = new Books() { AuthorId = book.AuthorId, Pages = book.Pages, Price = book.Price, Title = book.Title };
                    db.Books.Add(newBook);
                }
                else
                {
                    Books oldBook = db.Books.Where(a => a.Id == book.Id).FirstOrDefault();
                    oldBook.AuthorId = book.AuthorId;
                    oldBook.Title = book.Title;
                    oldBook.Pages = book.Pages;
                    oldBook.Price = book.Price;
                }   
                db.SaveChanges();
            }
            return RedirectToActionPermanent("Index", "Book");
        }


        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var book = db.Books.Where(a => a.Id == id).FirstOrDefault();
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Book");
        }
    }
}