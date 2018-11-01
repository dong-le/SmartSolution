using Store.DAL;
using System.Collections.Generic;
using System.Linq;
using Store.Entities;

namespace Store.Service
{
    // operations you want to expose
    public partial interface IGadgetService
    {
        IEnumerable<Gadget> GetGadgets();
        IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null);
        Gadget GetGadget(int id);
        void CreateGadget(Gadget gadget);
    }

    public partial class GadgetService : IGadgetService
    {
        private readonly IRepository<Gadget> _gadgetsRepository;
        private readonly ICategoryService _categoryService;

        public GadgetService(IRepository<Gadget> gadgetsRepository, ICategoryService categoryService)
        {
            this._gadgetsRepository = gadgetsRepository;
            this._categoryService = categoryService;
        }

        #region IGadgetService Members

        public IEnumerable<Gadget> GetGadgets()
        {
            var gadgets = _gadgetsRepository.Table;
            return gadgets;
        }

        public IEnumerable<Gadget> GetCategoryGadgets(string categoryName, string gadgetName = null)
        {
            var category = _categoryService.GetCategoryByName(categoryName);
            return category.Gadgets.Where(g => g.Name.ToLower().Contains(gadgetName.ToLower().Trim()));
        }

        public Gadget GetGadget(int id)
        {
            var gadget = _gadgetsRepository.GetById(id);
            return gadget;
        }

        public void CreateGadget(Gadget gadget)
        {
            _gadgetsRepository.Insert(gadget);
        }
        #endregion
    
    }
}
