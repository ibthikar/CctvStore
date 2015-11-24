using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class SpVideo
    {
        [Key]
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }
        [Display(Name = "Video Compression")]
        public string VideoCompression { get; set; }
         [Display(Name = "Encode Ability")]
        public string EncodeAbility { get; set; }
        [Display(Name = "Decode Ability")]
        public string DecodeAbility { get; set; }
         [Display(Name = "Video Input")]
        public string VideoInput { get; set; }
    }
}
