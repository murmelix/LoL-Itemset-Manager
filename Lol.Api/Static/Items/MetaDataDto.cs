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
    public class MetaDataDto
    {
        [DataMember(Name = "isRune"), XmlElement(ElementName = "isRune")]
        public bool IsRune { get; set; }
        [DataMember(Name = "tier"), XmlElement(ElementName = "tier")]
        public string Tier { get; set; }
        [DataMember(Name = "type"), XmlElement(ElementName = "type")]
        public string Type { get; set; }
    }
}
