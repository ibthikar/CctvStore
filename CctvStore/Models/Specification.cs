using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class Specification
    {
        public int SpecificationId { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual SpCamera SpCamera { get; set; }
        public virtual SpAudio SpAudio { get; set; }
        public virtual SpGeneral SpGeneral { get; set; }
        public virtual SpHardDisk SpHardDisk { get; set; }
        public virtual SpImage SpImage { get; set; }
        public virtual SpInterface SpInterface { get; set; }
        public virtual SpNetwork SpNetwork { get; set; }

        public virtual SpRecordPlayback SpRecordPlayback { get; set; }
        public virtual SpVideo SpVideo { get; set; }
        public virtual SpVideoAudioInput SpVideoAudioInput { get; set; }
        public virtual SpVideoAudioOutput SpVideoAudioOutput { get; set; }
        
    }
}
