using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class StateModel
    {
        public int ProductCount { get; set; }
        public int OrderCount { get; set; }
        public int BekleyenSiparisCount { get; set; }
        public int TamamlananSiparisCount { get; set; }
        public int PaketlenenSiparisCount { get; set; }
        public int KargolananSiparisCount { get; set; }
    }
}