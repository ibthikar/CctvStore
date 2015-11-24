using CctvStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.ViewModel
{
    public class CatalogCategoryVM
    {
        public IEnumerable<Catalog> Catalogs { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<SubCategory> SubCategory { get; set; }
        public IEnumerable<Product> Product { get; set; }

    }
}
