using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class Accessories
    {
        public int AccessoriesId { get; set; }
        public string Title { get; set; }
        public string UrlImageAccessory { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}