using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class SpHardDisk
    {
        [Key]
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }

        [Display(Name = "SATA HDD")]
        public string SATAHDD { get; set; }
        [Display(Name = "Mounting Mode")]
        public string MountingMode { get; set; }
        public string Cpacity { get; set; }
    }

}
