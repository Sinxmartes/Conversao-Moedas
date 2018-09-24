using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conversao.Models
{
    public class CurrencyConversion
    {
        public bool success { get; set; }
        public string terms { get; set; }
        public string privacy { get; set; }
        public Query query { get; set; }
        public Info info { get; set; }
        public double result { get; set; }
    }
}
