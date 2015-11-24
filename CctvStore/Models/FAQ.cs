using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CctvStore.Models
{
    public class FAQ
    {
        [Key]
        public int FAQId { get; set; }
        public string Question { get; set; }
    
        public string Answer { get; set; }
        public DateTime UploadDate { get; set; }
     
    }
}