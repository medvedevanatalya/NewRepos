using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Repositories;

namespace WebApplication2.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Model1 db;
        private bool disposed = false;

        Repository<Authors> authorUoWRepository;
        Repository<Books> bookUoWRepository;
        Repository<OrdersBooks> orderBookUoWRepository;
        Repository<Users> userUoWRepository;

        public Repository<Authors> AuthorUoWRepository
        {
            get
            {
                return authorUoWRepository == null ? new Repository<Authors>(db) : authorUoWRepository;
            }
        }

        public Repository<Books> BookUoWRepository
        {
            get
            {
                return bookUoWRepository == null ? new Repository<Books>(db) : bookUoWRepository;
            }
        }

        public Repository<OrdersBooks> OrderBookUoWRepository
        {
            get
            {
                return orderBookUoWRepository == null ? new Repository<OrdersBooks>(db) : orderBookUoWRepository;
            }
        }

        public Repository<Users> UserUoWRepository
        {
            get
            {
                return userUoWRepository == null ? new Repository<Users>(db) : userUoWRepository;
            }
        }

        public UnitOfWork()
        {
            db = new Model1();
        }
        public UnitOfWork(Model1 db)
        {
            this.db = db;
            db.Database.CommandTimeout = 180;
        }

        public void BeginTransaction()
        {
            db.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            db.Database.CurrentTransaction.Commit();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                if (disposing)
                {
                    if (db != null)
                    {
                        db.Dispose();
                    }
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}