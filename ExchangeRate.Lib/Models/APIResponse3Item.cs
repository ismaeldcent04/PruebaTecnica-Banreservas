using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Lib.Models
{
    public class APIResponse3Item
    {
        [JsonProperty("rate")]
        public decimal Rate { get; set; }    
    }
}
