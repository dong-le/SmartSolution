using Store.DAL;
using System.Collections.Generic;
using System.Linq;
using Store.Entities;

namespace Store.Service
{
    // operations you want to expose
    public partial interface ICategoryService
    {
        Category GetCategoryByName(string categoryName);
        IEnumerable<Category> GetCategories(string name = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        void CreateCategory(Category category);
    }

    public partial class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        #region ICategoryService Members

        public Category GetCategoryByName(string categoryName)
        {
            var category = this._categoryRepository.Table.FirstOrDefault(c => c.Name == categoryName);

            return category;
        }

        public IEnumerable<Category> GetCategories(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return _categoryRepository.Table;
            else
                return _categoryRepository.Table.Where(c => c.Name == name);
        }

        public Category GetCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            return category;
        }

        public Category GetCategory(string name)
        {
            var category = GetCategoryByName(name);
            return category;
        }

        public void CreateCategory(Category category)
        {
            _categoryRepository.Insert(category);
        }
        #endregion
    }
}
