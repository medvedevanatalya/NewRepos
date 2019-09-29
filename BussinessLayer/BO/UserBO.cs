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
    public class UserBO : BusinessObjectBase
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public string FIO { get; set; }
        public string EmailUser { get; set; }

        public UserBO(IMapper mapper, UnitOfWorkFactory unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public UserBO GetUserById(int? id)
        {
            UserBO user;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                user = unitOfWork.UserUoWRepository.GetAll().Where(u => u.Id == id).Select(item => mapper.Map<UserBO>(item)).FirstOrDefault();
            }
            return user;
        }

        public List<UserBO> GetUsersList()
        {
            List<UserBO> users = new List<UserBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                users = unitOfWork.UserUoWRepository.GetAll().Select(item => mapper.Map<UserBO>(item)).ToList();
            }
            return users;
        }

        void Add(IUnitOfWork unitOfWork)
        {
            var author = mapper.Map<Users>(this);
            unitOfWork.UserUoWRepository.Add(author);
            unitOfWork.Save();
        }

        void Update(IUnitOfWork unitOfWork)
        {
            var author = mapper.Map<Users>(this);
            unitOfWork.UserUoWRepository.Update(author);
            unitOfWork.Save();
        }

        public void Save()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                if (Id != 0)
                    Update(unitOfWork);
                else
                    Add(unitOfWork);
            }
        }       

        public void Delete(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.UserUoWRepository.Delete(id);
                unitOfWork.Save();
            }
        }
    }
}
