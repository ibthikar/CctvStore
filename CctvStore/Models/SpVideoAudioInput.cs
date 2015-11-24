using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class SpVideoAudioInput
    {
        [Key]
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }
        [Display(Name = "VideoInput")]
        public string VideoInput { get; set; }
        [Display(Name = "IncomingBandwidth")]
        public string IncomingBandwidth { get; set; }
        [Display(Name = "OutgoingChannel")]
        public string OutgoingChannel { get; set; }
        [Display(Name = "AudioInput")]
        public string AudioInput { get; set; }
    }
}
