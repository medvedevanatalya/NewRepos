using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext db = null;
        private readonly DbSet<T> table = null;

        public Repository()
        {
            db = new Model1();
            table = db.Set<T>();
        }

        public Repository(DbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
       
        public T Get(int? id)
        {
            T entity = table.Find(id);
            return entity;
        }

        public void Add(T entity)
        {
            table.Add(entity);
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T existingEntity = table.Find(id);
            table.Remove(existingEntity);
        }

        public void Save()
        {
            db.SaveChanges();
        }


    }
}