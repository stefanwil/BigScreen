using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigScreen.Models
{
    public class DeviceWindow
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string DevicePixelRatio { get; set; }
        public string DotsPerInch { get; set; }


    }
}
