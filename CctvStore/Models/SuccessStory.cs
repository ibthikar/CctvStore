using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{ public enum story { Cases,Solution}
    public class SuccessStory
    {
        public int SuccessStoryId { get; set; }
        public string Title { get; set; }
        public story Stories { get; set; }
        public string SuccessStoryUrl { get; set; }
    }
}
