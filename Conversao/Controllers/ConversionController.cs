using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Conversao.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Conversao.Controllers
{
    [Produces("application/json")]    
    public class ConversionController : Controller
    {
        private string key = "8e1bb7a347da7f041d560e521d0dc17e";
        private string url = "http://apilayer.net/api/";
        
      
        
        [Route("api/CurrenciesList")]
        [HttpGet]
        public CurrenciesList currenciesList()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));            
            HttpResponseMessage response = client.GetAsync(
                url + "list?" +
                $"access_key={key}").Result;
            response.EnsureSuccessStatusCode();
            string conteudo =
                response.Content.ReadAsStringAsync().Result;
            var retorno = JsonConvert.DeserializeObject<CurrenciesList>(conteudo);
            return retorno;
        }
        
        [Route("api/CurrenciesLive/{de}&{para}")]
        [HttpGet]
        public CurrencyLive currencyLive(string de, string para)
        {           
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(
                url + "live?" +
                $"access_key={key}" +
                $"&currencies={de},{para}").Result;
            response.EnsureSuccessStatusCode();
            string conteudo =
                response.Content.ReadAsStringAsync().Result;
            var retorno = JsonConvert.DeserializeObject<CurrencyLive>(conteudo);            
            return retorno;    
        }

        [Route("api/CurrencyConversion/{de}&{para}/{valor?}")]
        [HttpGet]
        public double currencyConversion(string de, string para, double valor = 1.00)
        {
            var currencyDe = currencyLive(de, para);
            List<double> valores = new List<double>();
            foreach(var item in currencyDe.quotes)
            {
                valores.Add((double)item.Value);
            }
            var retorno = Math.Round((valores[1] / valores[0]) * valor, 2);
            return retorno;
        }
    }
}