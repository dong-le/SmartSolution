using Store.Data.Infrastructure;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.FirstOrDefault(c => c.Name == categoryName);

            return category;
        }

        public override void Update(Category entity)
        {
            entity.DateUpdated = DateTime.Now;
            base.Update(entity);
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }
}
