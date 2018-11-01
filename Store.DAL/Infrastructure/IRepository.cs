using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Store.Entities;

namespace Store.DAL
{
    public partial interface IRepository<T> where T : BaseEntity
    {
        // Marks an entity as new
        void Insert(T entity);
        // Marks an entity as modified
        void Update(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        // Get an entity by int id
        T GetById(int id);
        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);
        // Gets all entities of type T
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        /// Gets a table
        IEnumerable<T> Table { get; }
    }
}
