using System;
using System.Collections.Generic;

namespace Store.Entities
{
    public partial class Gadget
    {
        public int GadgetID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
