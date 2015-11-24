using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CctvStore.Models
{
    public class ProductDownloads
    {
        [Key]
        public int ProductDownloadId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}