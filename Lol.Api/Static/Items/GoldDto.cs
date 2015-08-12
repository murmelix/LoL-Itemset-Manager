using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lol.Api.Static.Items
{
    [DataContract]
    public class GoldDto
    {
        [DataMember(Name = "base"), XmlElement(ElementName = "base")]
        public int Base { get; set; }
        [DataMember(Name = "purchasable"), XmlElement(ElementName = "purchasable")]
        public bool Purchasable { get; set; }
        [DataMember(Name = "sell"), XmlElement(ElementName = "sell")]
        public int Sell { get; set; }
        [DataMember(Name = "total"), XmlElement(ElementName = "total")]
        public int Total { get; set; }
    }
}
