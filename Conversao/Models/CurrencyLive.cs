using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conversao.Models
{
    public class CurrencyLive
    {
        public bool success { get; set; }
        public string terms { get; set; }
        public string privacy { get; set; }
        public int timestamp { get; set;}        
        public string source { get; set; }
        public dynamic quotes { get; set; }
    }
}
