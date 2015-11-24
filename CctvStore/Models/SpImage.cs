using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class SpImage
    {
        [Key]
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        public virtual Specification Specification { get; set; }
        [Display(Name = "Effective Resolution")]
        public string EffectiveResolution { get; set; }
        [Display(Name = "White Balance")]
        public string WhiteBalance { get; set; }
        public string Gain { get; set; }
        [Display(Name = "Light Compensation")]
        public string LightCompensation { get; set; }
        [Display(Name = "Digital Zoom")]
        public string DigitalZoom { get; set; }
        [Display(Name = "Motion Detection")]
        public string MotionDetection { get; set; }
        [Display(Name = "Private Mask")]
        public string PrivateMask { get; set; }
        [Display(Name = "OSD Language")]
        public string OSDLanguage { get; set; }
        public string Defog { get; set; }
        [Display(Name = "Digital Image Stable")]
        public string DigitalImageStable { get; set; }
        public string UTC { get; set; }
        [Display(Name = "Video Compression")]
        public string VideoCompression { get; set; }
        [Display(Name = "Bit Rate")]
        public string BitRate { get; set; }
        [Display(Name = "Audio Compression")]
        public string AudioCompression { get; set; }
        [Display(Name = "Max. Resolution")]
        public string MaxResolution { get; set; }
        public string Stream { get; set; }
        [Display(Name = "Image Setting")]
        public string ImageSetting { get; set; }
        [Display(Name = "De-Wrapping")]
        public string DeWrapping { get; set; }
        public string HLC { get; set; }
        [Display(Name = "9:16 Corridor Mode")]
        public string CorridorMode { get; set; }
        public string ROI { get; set; }
        [Display(Name = "Effective Pixel")]
        public string EffectivePixel { get; set; }
        [Display(Name = "DVE Image Enhance")]
        public string DVEImageEnhance { get; set; }
        [Display(Name = "Image Color Mode")]
        public string ImageColorMode { get; set; }
        [Display(Name = "3D Noise Reduce")]
        public string NoiseReduce { get; set; }
        [Display(Name = "Image Correction")]
        public string ImageCorrection { get; set; }
        [Display(Name = "Image Overturn")]
        public string ImageOverturn { get; set; }
        
    }
}
