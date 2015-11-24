using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CctvStore.Models
{
    public enum FileTypes
    {
        Software,
        Firmware,
        [Display(Name = "SDK & Tool")]
        SDKandTool,
         [Display(Name = "FAQ Document")]
        FAQDocument,
         [Display(Name = "Compatibility Tab")]
        CompatibilityTab
    }
    public class Support
    {
        [Key]
        public int DownloadId { get; set; }
        public string Title { get; set; }
        public FileTypes FileType { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public string DownloadUrl { get; set; }
    }
}