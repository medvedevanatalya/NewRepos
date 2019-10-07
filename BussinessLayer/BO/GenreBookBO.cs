using AutoMapper;
using DataLayer.Entities;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BussinessLayer.BO
{
    public class GenreBookBO : BusinessObjectBase
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public string NameGenre { get; set; }

        public GenreBookBO(IMapper mapper, UnitOfWorkFactory unitOfWorkFactory, IUnityContainer unityContainer)
           : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public GenreBookBO GetGenreBookById(int? id)
        {
            GenreBookBO book;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                book = unitOfWork.GenreBookUoWRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<GenreBookBO>(item)).FirstOrDefault();
            }
            return book;
        }

        public List<GenreBookBO> GetGenresBooksList()
        {
            List<GenreBookBO> genresBooks = new List<GenreBookBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                genresBooks = unitOfWork.GenreBookUoWRepository.GetAll().Select(item => mapper.Map<GenreBookBO>(item)).ToList();
            }
            return genresBooks;
        }

        void Add(IUnitOfWork unitOfWork)
        {
            var genreBook = mapper.Map<GenresBooks>(this);
            unitOfWork.GenreBookUoWRepository.Add(genreBook);
            unitOfWork.Save();
        }

        void Update(IUnitOfWork unitOfWork)
        {
            var genreBook = mapper.Map<GenresBooks>(this);
            unitOfWork.GenreBookUoWRepository.Update(genreBook);
            unitOfWork.Save();
        }

        public void Save()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                if (Id != 0)
                {
                    Update(unitOfWork);
                }
                else
                {
                    Add(unitOfWork);
                }
            }
        }

        public void Delete(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.GenreBookUoWRepository.Delete(id);
                unitOfWork.Save();
            }
        }
    }
}