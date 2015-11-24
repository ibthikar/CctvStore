using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class SpAudio
    {
        [Key]
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }

        [Display(Name = "Audio   Compression")]
        public string AudioCompression { get; set; }
        [Display(Name = "Two Way Audio")]
        public string TwoWayAudio { get; set; }
    }
}
