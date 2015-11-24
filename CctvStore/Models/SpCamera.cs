using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class SpCamera
    {
        [Key]
        [ForeignKey("Specification")]
        public int SpecificationId { get; set; }
        [Display(Name = "Image Sensor")]
        public string ImageSensor { get; set; }
        [Display(Name = "Min. illumination")]
        public string MinIllumination { get; set; }
        [Display(Name ="Day & Night")]
        public string DayNight { get; set; }
        [Display(Name ="Shutter Speed")]
        public string ShutterSpeed { get; set; }
        [Display(Name = "Auto Iris")]
        public string AutoIris { get; set; }
        [Display(Name = "Wide Dynamic Range")]
        public string WideDynamicRange { get; set; }
        [Display(Name = "Digital Noise Reduction")]
        public string DigitalNoiseReduction { get; set; }
        public string Lens { get; set; }
        public string FOV { get; set; }
        [Display(Name = "IR LED")]
        public string IRLED { get; set; }
        [Display(Name = "IR Range")]
        public string IRRange { get; set; }
        public string SN { get; set; }
        [Display(Name = "Signal System")]
        public string SignalSystem { get; set; }
        [Display(Name = "Detecter Type")]
        public string DetecterType { get; set; }
        [Display(Name = "Array Formal")]
        public string ArrayFormal { get; set; }
        [Display(Name = "Pixel Pitch")]
        public string PixelPitch { get; set; }
        public string Sensitivity { get; set; }
        [Display(Name = "Specteral Range")]
        public string SpecteralRange { get; set; }
        [Display(Name = "Temperature Detection")]
        public string TemperatureDetection { get; set; }
        public string Focus { get; set; }
        [Display(Name = "Detect Distance (Vehicle)")]
        public string DetectDistanceVehicle { get; set; }
        [Display(Name = "Detect Distance (Humen 1.8m)")]
        public string DetectDistanceHumen { get; set; }
        [Display(Name = "Recognize Distance")]
        public string RecognizeDistance { get; set; }
        public virtual Specification Specification { get; set; }
    }
}
