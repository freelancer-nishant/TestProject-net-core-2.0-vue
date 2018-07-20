using Demo.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Abstract
{
    public interface IEntityBaseRepository<T, key> : IDisposable where T : class, IEntityBase, new()
    {
        T Add(T entity);
        T GetById(key id);
        List<T> GetAll();
    }
}
