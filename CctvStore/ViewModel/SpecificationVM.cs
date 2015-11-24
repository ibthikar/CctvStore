using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CctvStore.Models;

namespace CctvStore.ViewModel
{
    public class SpecificationVM
    {
        public IEnumerable<Specification> Specification { get; set; }
        public IEnumerable<SpCamera> SpCamera { get; set; }
        public IEnumerable<SpImage> SpImage { get; set; }
        public IEnumerable<SpInterface> SpInterface { get; set; }
        public IEnumerable<SpGeneral> SpGeneral { get; set; }
    }
}
