using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Model { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string UrlProductImage { get; set; }
        public int? SubCategoryId { get; set; }      
        public virtual SubCategory SubCategory { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int? CatalogId { get; set; }
        public virtual Catalog Catalog { get; set; }
        //public ICollection<ProductProperty> ProductProperties { get; set; }
        public ICollection<Accessories> Accessories { get; set; }
        public ICollection<ProductDownloads> ProductDownloads { get; set; }
    }
}
