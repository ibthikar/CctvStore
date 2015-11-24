using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class News
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; private set; }
        public string NewsUrl { get; set; }

    }
}
