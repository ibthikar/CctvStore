using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class SpRecordPlayback
    {
        [Key]
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }
        [Display(Name = "Hard Drive")]
        public string HardDrive { get; set; }
        
        public string Record { get; set; }
        
        public string PlayBack { get; set; }
    }
}
