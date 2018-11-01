using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Store.Entities;

namespace Store.DAL
{
    public partial class StoreEntities : IDbContext
    {
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new Exception();
        }

    }
}
