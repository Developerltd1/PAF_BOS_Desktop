using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServicePAFBOS.Models
{
    public class MdlGroundCadel
    {
        public int Cadet_ID { get; set; }
        public string CadetName { get; set; }
        public string Picture { get; set; }
        public string ActivityTitle { get; set; }
        public string Description { get; set; }
        public DateTime CadetCheckInTime { get; set; }
        public DateTime CadetCheckOutTime { get; set; }
        public DateTime ChecnInActualTime { get; set; }
        public DateTime CheckOutActualTime { get; set; }
    }
}