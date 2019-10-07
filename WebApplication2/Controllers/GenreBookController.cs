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
    public class GenreBookController : Controller
    {
        // GET: GenreBook
        protected IMapper mapper;

        public GenreBookController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            var genreBookBO = DependencyResolver.Current.GetService<GenreBookBO>();
            var genresBooksList = genreBookBO.GetGenresBooksList();
            ViewBag.GenresBooks = genresBooksList.Select(a => mapper.Map<GenreBookViewModel>(a)).ToList();
 
            return View();
        }

        public ActionResult CreateAndEdit(int? id)
        {
            var genreBookBO = DependencyResolver.Current.GetService<GenreBookBO>();
            var genresBooksModel = mapper.Map<GenreBookViewModel>(genreBookBO);

            if (id == null)
            {
                ViewBag.Header = "Создание жанра";
            }
            else
            {
                var genreBookBOList = genreBookBO.GetGenreBookById(id);
                genresBooksModel = mapper.Map<GenreBookViewModel>(genreBookBOList);
                ViewBag.Header = "Редактирование жанра";
            }

            return View(genresBooksModel);
        }

        [HttpPost]
        public ActionResult CreateAndEdit(GenreBookViewModel genresBooksModel)
        {
            var genreBookBO = mapper.Map<GenreBookBO>(genresBooksModel);
            if (ModelState.IsValid)
            {
                genreBookBO.Save();
                return RedirectToActionPermanent("Index", "GenreBook");
            }
            else
            {
                return View(genresBooksModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var genreBook = DependencyResolver.Current.GetService<GenreBookBO>().GetGenreBookById(id);
            genreBook.Delete(id);

            return RedirectToActionPermanent("Index", "GenreBook");
        }
    }
}