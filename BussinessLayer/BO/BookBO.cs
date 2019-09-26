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
    public class BookBO : BusinessObjectBase
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int? Pages { get; set; }
        public int? Price { get; set; }

        public BookBO(IMapper mapper, UnitOfWorkFactory unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public BookBO GetBookById(int? id)
        {
            BookBO book;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                book = unitOfWork.BookUoWRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<BookBO>(item)).FirstOrDefault();
            }
            return book;
        }

        public List<BookBO> GetBooksList()
        {
            List<BookBO> books = new List<BookBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                books = unitOfWork.BookUoWRepository.GetAll().Select(item => mapper.Map<BookBO>(item)).ToList();
            }
            return books;
        }

        void Add(IUnitOfWork unitOfWork)
        {
            var book = mapper.Map<Books>(this);
            unitOfWork.BookUoWRepository.Add(book);
            unitOfWork.Save();
        }

        void Update(IUnitOfWork unitOfWork)
        {
            var book = mapper.Map<Books>(this);
            unitOfWork.BookUoWRepository.Update(book);
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
                unitOfWork.BookUoWRepository.Delete(id);
                unitOfWork.Save();
            }
        }
    }
}
