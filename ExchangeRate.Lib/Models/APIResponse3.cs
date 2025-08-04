using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Lib.Models
{
    public class APIResponse3
    {
        [JsonProperty("result")]
        public APIResponse3Item Result { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
