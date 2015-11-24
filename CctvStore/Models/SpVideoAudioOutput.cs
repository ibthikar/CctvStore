using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class SpVideoAudioOutput
    {
        [Key]
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }
        [Display(Name = "Recording Resolution")]
        public string RecordingResolution { get; set; }
        [Display(Name = "Frame Rate")]
        public string FrameRate { get; set; }
        [Display(Name = "Live View/Playback Resolution")]
        public string LiveviewPlaybackResolution { get; set; }
        [Display(Name = "Live View/Playback Capacity")]
        public string LiveviewPlaybackCapacity { get; set; }
        [Display(Name = "HDMI/VGA")]
        public string HDMIVGA { get; set; }
        [Display(Name = "Audio Output")]
        public string AudioOutput { get; set; }
    }
}
