using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conversao.Models
{
    public class CurrenciesList
    {
        public bool success { get; set; }
        public string terms { get; set; }
        public string privacy { get; set; }
        public dynamic currencies { get; set; }
    }
}
