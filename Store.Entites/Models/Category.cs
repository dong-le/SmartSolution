using System;
using System.Collections.Generic;

namespace Store.Entities
{
    public partial class Category
    {
        public Category()
        {
            this.Gadgets = new List<Gadget>();
        }

        public int CategoryID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateUpdated { get; set; }
        public virtual ICollection<Gadget> Gadgets { get; set; }
    }
}
