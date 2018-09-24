using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conversao.Models;

namespace Front_Conversao.Models
{
    public class ConversaoViewModel
    {
        public CurrenciesList CurrenciesList { get; set; }
        public string De { get; set; }
        public string Para { get; set; }
        public string Valor { get; set; }
    }
}
