using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExchangeRate.Lib.Models
{
    [XmlRoot("channel")]
    public class APIResponse2
    {
        [XmlElement("baseCurrency")]
        public string BaseCurrency { get; set; }

        [XmlElement("item")]
        public List<APIResponse2Item> Items { get; set; }
    }
}
