using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class SpGeneral
    {
        [Key]
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }

        [Display(Name = "Power Supply")]
        public string PowerSupply { get; set; }
        [Display(Name = "Power Consumption")]
        public string PowerConsumption { get; set; }
        [Display(Name = "Operature Temperature")]
        public string OperatureTemperature { get; set; }
        [Display(Name = "Ingress Protection")]
        public string IngressProtection { get; set; }
        public string Approvals { get; set; }
        [Display(Name = "Product Dimensions")]
        public string ProductDimensions { get; set; }
        [Display(Name = "Product Weight")]
        public string ProductWeight { get; set; }
        public string Materials { get; set; }
        public string Size { get; set; }
        public string Chasis { get; set; }
    }
}
