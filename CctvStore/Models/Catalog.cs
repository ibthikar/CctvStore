using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class Catalog
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
