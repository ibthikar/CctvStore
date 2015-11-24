using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CctvStore.Models
{
    public class TroubleShooting
    {
        public TroubleShooting()
        {
            this.DateCreated = DateTime.Now;
        }
        public int TroubleShootingId { get; set; }
        [StringLength(50)]
        [Display(Name = "Error Title")]
        public string ErrorTitle { get; set; }
        [Display(Name = "Error Description")]
        public string ErrorDescription { get; set; }
        public string  ErrorUrl { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; private set; }
    }
}
