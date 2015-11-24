using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class Download
    {
        public int DownloadId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Introduction { get; set; }
        [Display(Name = "Features from SDK")]
        public string FeaturesfromSDK { get; set; }
        public string DownloadUrl { get; set; }
    }
}
