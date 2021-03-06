﻿using AutoMapper;
using BussinessLayer.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        #region    До разделениия проекта на слои

        #region        До добавления UnitOfWork
        //// GET: Book
        //public ActionResult Index()
        //{
        //    List<Books> books;
        //    using (Model1 db = new Model1())
        //    {
        //        books = db.Books.ToList();
        //    }
        //    return View(books);
        //}


        //#region Views Create Edit
        ////public ActionResult Create()
        ////{
        ////    return View();
        ////}

        ////[HttpPost]
        ////public ActionResult Create(Books book)
        ////{
        ////    using (Model1 db = new Model1())
        ////    {
        ////        db.Books.Add(book);
        ////        db.SaveChanges();
        ////    }
        ////    return Redirect("Index");
        ////}

        ////public ActionResult Edit(int? id)
        ////{
        ////    Books book;
        ////    using (Model1 db = new Model1())
        ////    {
        ////        book = db.Books.Where(a => a.Id == id).FirstOrDefault();
        ////    }
        ////    return View(book);
        ////}

        ////[HttpPost]
        ////public ActionResult Edit(Books book)
        ////{
        ////    using (Model1 db = new Model1())
        ////    {
        ////        var oldBook = db.Books.Where(a => a.Id == book.Id).FirstOrDefault();
        ////        oldBook.AuthorId = book.AuthorId;
        ////        oldBook.Title = book.Title;
        ////        oldBook.Pages = book.Pages;
        ////        oldBook.Price = book.Price;

        ////        db.SaveChanges();
        ////    }
        ////    return RedirectToActionPermanent("Index", "Book");
        ////}
        //#endregion

        //public ActionResult CreateAndEdit(int? id)
        //{
        //    Books book;
        //    List<Authors> authors;   

        //    using (Model1 db = new Model1())
        //    {
        //        authors = db.Authors.ToList();
        //        ViewBag.Authors = new SelectList(authors, "Id", "FirstName");
        //        book = db.Books.Where(a => a.Id == id).FirstOrDefault();
        //    }
        //    return View(book);
        //}

        //[HttpPost]
        //public ActionResult CreateAndEdit(Books book)
        //{
        //    using (Model1 db = new Model1())
        //    {
        //        if(book.Id==0)
        //        {
        //            Books newBook = new Books() { AuthorId = book.AuthorId, Pages = book.Pages, Price = book.Price, Title = book.Title };
        //            db.Books.Add(newBook);
        //        }
        //        else
        //        {
        //            Books oldBook = db.Books.Where(a => a.Id == book.Id).FirstOrDefault();
        //            oldBook.AuthorId = book.AuthorId;
        //            oldBook.Title = book.Title;
        //            oldBook.Pages = book.Pages;
        //            oldBook.Price = book.Price;
        //        }   
        //        db.SaveChanges();
        //    }
        //    return RedirectToActionPermanent("Index", "Book");
        //}


        //public ActionResult Delete(int id)
        //{
        //    using (Model1 db = new Model1())
        //    {
        //        var book = db.Books.Where(a => a.Id == id).FirstOrDefault();
        //        db.Books.Remove(book);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index", "Book");
        //}
        #endregion

        #region После добавления UnitOfWork

        //WebApplication2.UnitOfWork.UnitOfWork unitOfWork;
        //public BookController()
        //{
        //    unitOfWork = new UnitOfWork.UnitOfWork();
        //}

        //public ActionResult Index()
        //{
        //    var model = unitOfWork.BookUoWRepository.GetAll();
        //    return View(model);
        //}

        //public ActionResult CreateAndEdit(int? id)
        //{
        //    var authors = unitOfWork.AuthorUoWRepository.GetAll();
        //    ViewBag.Authors = new SelectList(authors, "Id", "FirstName");

        //    Books model = unitOfWork.BookUoWRepository.Get(id);
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult CreateAndEdit(Books book)
        //{
        //    if (book.Id == 0)
        //    {
        //        unitOfWork.BookUoWRepository.Add(book);
        //    }
        //    else
        //    {
        //        unitOfWork.BookUoWRepository.Update(book);
        //    }
        //    unitOfWork.BookUoWRepository.Save();

        //    return RedirectToActionPermanent("Index", "Book");
        //}

        //public ActionResult Delete(int id)
        //{
        //    unitOfWork.BookUoWRepository.Delete(id);
        //    unitOfWork.BookUoWRepository.Save();

        //    return RedirectToActionPermanent("Index", "Book");
        //}

        #endregion

        #endregion


        #region После разделения на слои

        protected IMapper mapper;

        public BookController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var bookBO = DependencyResolver.Current.GetService<BookBO>().GetBooksList();
            var authorBO = DependencyResolver.Current.GetService<AuthorBO>().GetAuthorsList();
            var genreBookBO = DependencyResolver.Current.GetService<GenreBookBO>().GetGenresBooksList();
            //foreach (var item in bookBO)
            //{
            //    if (item.ImageMimeType != null)
            //    {
            //        GetImage(item.Id);
            //    }
            //}
            ViewBag.Books = bookBO.Select(m => mapper.Map<BookViewModel>(m)).ToList();
            ViewBag.Authors = authorBO.Select(m=> mapper.Map<AuthorViewModel>(m)).ToList();
            ViewBag.GenresBooks = genreBookBO.Select(m=> mapper.Map<GenreBookViewModel>(m)).ToList();

            return View();
        }

        public ActionResult CreateAndEdit(int? id)
        {
            var bookBO = DependencyResolver.Current.GetService<BookBO>();
            var authorBO = DependencyResolver.Current.GetService<AuthorBO>();
            var genreBookBO = DependencyResolver.Current.GetService<GenreBookBO>();

            var booksModel = mapper.Map<BookViewModel>(bookBO);

            if (id == null)
            {
                ViewBag.Header = "Создание книги"; 
            }
            else
            {
                var bookBOList = bookBO.GetBookById(id);
                booksModel = mapper.Map<BookViewModel>(bookBOList);
                ViewBag.Header = "Редактирование книги";
            }

            ViewBag.Authors = new SelectList(authorBO.GetAuthorsList().Select(m => mapper.Map<AuthorViewModel>(m)).ToList(), "Id", "LastName");
            ViewBag.GenresBooks = new SelectList(genreBookBO.GetGenresBooksList().Select(m => mapper.Map<GenreBookViewModel>(m)).ToList(), "Id", "NameGenre");

            return View(booksModel);
        }

        [HttpPost]
        public ActionResult CreateAndEdit(BookViewModel booksModel, HttpPostedFileBase image)
        {                                                
            var bookBO = mapper.Map<BookBO>(booksModel);
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    bookBO.ImageMimeType = image.ContentType;
                    bookBO.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(bookBO.ImageData, 0, image.ContentLength);
                }
                bookBO.Save();
                return RedirectToActionPermanent("Index", "Book");
            }
            else
            {
                return View(booksModel);
            }          
        }

        public ActionResult Delete(int id)
        {
            var book = DependencyResolver.Current.GetService<BookBO>().GetBookById(id);
            book.Delete(id);

            return RedirectToActionPermanent("Index", "Book");
        }

        public FileContentResult GetImage(int bookId)
        {
            var book = DependencyResolver.Current.GetService<BookBO>().GetBookById(bookId);

            if (book != null)
            {
                return File(book.ImageData, book.ImageMimeType);
            }
            else
            {
                return null;
            } 
        }
        #endregion
    }
}