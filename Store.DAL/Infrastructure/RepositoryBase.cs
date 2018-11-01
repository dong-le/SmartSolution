using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using Store.Entities;

namespace Store.DAL
{
    public partial class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        #region Properties
        private readonly IDbContext _dataContext;
        private IDbSet<T> _dbSet;

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual IDbSet<T> Entities
        {
            get { return _dbSet ?? (_dbSet = _dataContext.Set<T>()); }
        }
        #endregion

        public RepositoryBase(IDbContext context)
        {
            this._dataContext = context;
        }

        #region Utilities

        /// <summary>
        /// Get full error
        /// </summary>
        /// <param name="exc">Exception</param>
        /// <returns>Error</returns>
        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg += string.Format("Property: {0} Error: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
            return msg;
        }

        #endregion

        #region Implementation
        public virtual void Update(T entity)
        {
            this.Entities.Attach(entity);
            
            this._dataContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            this.Entities.Remove(entity);

            this._dataContext.SaveChanges();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                this.Entities.Remove(obj);

            this._dataContext.SaveChanges();
        }

        public virtual T GetById(int id)
        {
            return Entities.Find(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return this.Entities.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return this.Entities.Where(where).FirstOrDefault<T>();
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Entities.Add(entity);

            this._dataContext.SaveChanges();
        }
        #endregion

        public IEnumerable<T> Table
        {
            get { return this.Entities;  }
        }
    }
}