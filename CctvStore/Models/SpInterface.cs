using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
   public class SpInterface
    {
        [Key]
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }

        public string Ethernet { get; set; }
        [Display(Name = "Audio I/O")]
        public string AudioIO { get; set; }
        [Display(Name = "Alarm I/O")]
        public string AlarmIO { get; set; }
       
        public string RS485 { get; set; }
        [Display(Name = "BNC Output")]
        public string BNCOutput { get; set; }
        [Display(Name = "Reset Button")]
        public string ResetButton { get; set; }
        [Display(Name = "Edge Storage")]
        public string EdgeStorage { get; set; }
        public string Output { get; set; }
        [Display(Name = "PTZ Control")]
        public string PTZControl { get; set; }
        public string Network { get; set; }
        public string USB { get; set; }
        [Display(Name = "HDMI/VGA")]
        public string HDMIVGA { get; set; }
       
    }
}
