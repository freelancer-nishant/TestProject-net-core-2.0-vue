using Demo.DAL.Abstract;
using Demo.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Demo.DAL.Repositories
{
    public class EntityBaseRepository<T, Key> : IEntityBaseRepository<T, Key> where T : class, IEntityBase, new()
    {
        private DemoDbContext db;    //my database context
        protected DbSet<T> entities;  //specific set

        protected EntityBaseRepository(DemoDbContext db)
        {
            entities = db.Set<T>();
            this.db = db;
        }

        public T Add(T entity)
        {
            entities.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public T GetById(Key id)
        {
            return entities.Find(id);
        }

        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
