using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExchangeRate.Lib.Models
{
    public class APIResponse2Item
    {
        [XmlElement("targetCurrency")]
        public string TargetCurrency { get; set; }

        [XmlElement("exchangeRate")]
        public decimal ExchangeRate { get; set; }

        [XmlElement("baseCurrency")]
        public string BaseCurrency { get; set; }
    }
}
