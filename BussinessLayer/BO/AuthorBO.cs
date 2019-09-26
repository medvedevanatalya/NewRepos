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
    public class AuthorBO  : BusinessObjectBase
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AuthorBO(IMapper mapper, UnitOfWorkFactory unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public AuthorBO GetAuthorById(int? id)
        {
            AuthorBO author;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                author = unitOfWork.AuthorUoWRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<AuthorBO>(item)).FirstOrDefault();
            }
            return author;
        }

        public List<AuthorBO> GetAuthorsList()
        {
            List<AuthorBO> authors = new List<AuthorBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                authors = unitOfWork.AuthorUoWRepository.GetAll().Select(item => mapper.Map<AuthorBO>(item)).ToList();
            }
            return authors;
        }

        void Add(IUnitOfWork unitOfWork)
        {
            var author = mapper.Map<Authors>(this);
            unitOfWork.AuthorUoWRepository.Add(author);
            unitOfWork.Save();
        }

        void Update(IUnitOfWork unitOfWork)
        {
            var author = mapper.Map<Authors>(this);
            unitOfWork.AuthorUoWRepository.Update(author);
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
                unitOfWork.AuthorUoWRepository.Delete(id);
                unitOfWork.Save();
            }
        }
    }
}
