using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class SpNetwork
    {
        [Key]
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }

        [Display(Name = "Network Protocols")]
        public string NetworkProtocols { get; set; }
        [Display(Name = "Alarm Trigger")]
        public string AlarmTrigger { get; set; }
        [Display(Name = "RTSP Video")]
        public string RTSPVideo { get; set; }
        public string Security { get; set; }
        [Display(Name = "Web Language")]
        public string WebLanguage { get; set; }
        [Display(Name = "System Compatibility")]
        public string SystemCompatibility { get; set; }
        [Display(Name = "Network Interface")]
        public string NetworkInterface { get; set; }
        [Display(Name = "POE Interface")]
        public string POEInterface { get; set; }
        [Display(Name = "POE MaxPower")]
        public string POEMaxPower { get; set; }
    }
}
