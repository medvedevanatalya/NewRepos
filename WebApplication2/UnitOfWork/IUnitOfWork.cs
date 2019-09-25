using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Repositories;

namespace WebApplication2.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Authors> AuthorUoWRepository { get; }
        Repository<Books> BookUoWRepository { get; }
        Repository<OrdersBooks> OrderBookUoWRepository { get; }
        Repository<Users> UserUoWRepository { get; }

        void Save();
        void BeginTransaction();
        void CommitTransaction();   
    }
}
