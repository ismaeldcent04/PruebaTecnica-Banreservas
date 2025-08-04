using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace ExchangeRate.Models
{
    public class APIResponse1
    {

        [JsonProperty("conversion_result")]
        public decimal ConversionResult { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }
    }
}
