using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverBear.ValueObjects
{
    public class ComputerInfo
    {
        public int appId { get; set; }
        public string ram { get; set; }
        public string hdd { get; set; }
        public string ports { get; set; }
        public string display { get; set; }
        public string weight { get; set; }
        public string power { get; set; }
        public string cpu { get; set; }
    }
}
