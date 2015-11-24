using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? CatalogId { get; set; }
        public virtual Catalog Catalog { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
