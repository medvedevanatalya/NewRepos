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
    public class OrderBookBO : BusinessObjectBase
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual int BookId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? ReturnDate { get; set; }

        public OrderBookBO(IMapper mapper, UnitOfWorkFactory unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public OrderBookBO GetOrderBookById(int? id)
        {
            OrderBookBO order;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                order = unitOfWork.OrderBookUoWRepository.GetAll().Where(o => o.Id == id).Select(item => mapper.Map<OrderBookBO>(item)).FirstOrDefault();
            }
            return order;
        }

        public List<OrderBookBO> GetOrdersBookssList()
        {
            List<OrderBookBO> orders = new List<OrderBookBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                orders = unitOfWork.OrderBookUoWRepository.GetAll().Select(item => mapper.Map<OrderBookBO>(item)).ToList();
            }
            return orders;
        }

        void Add(IUnitOfWork unitOfWork)
        {
            var order = mapper.Map<OrdersBooks>(this);
            unitOfWork.OrderBookUoWRepository.Add(order);
            unitOfWork.Save();
        }

        void Update(IUnitOfWork unitOfWork)
        {
            var order = mapper.Map<OrdersBooks>(this);
            unitOfWork.OrderBookUoWRepository.Update(order);
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
                unitOfWork.OrderBookUoWRepository.Delete(id);
                unitOfWork.Save();
            }
        }
    }
}
