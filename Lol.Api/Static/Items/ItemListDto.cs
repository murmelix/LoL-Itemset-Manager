using Lol.Api.Toolkit;
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
    public class ItemListDto
    {
        [DataMember(Name="basic"), XmlElement(ElementName="basic")]
        public BasicDataDto Basic { get; set; }
        [DataMember(Name = "data"), XmlArray(ElementName = "data"), XmlArrayItem(ElementName="item")]
        public List<ItemDto> Data { get; set; }
        [DataMember(Name = "groups"), XmlArray(ElementName = "groups"), XmlArrayItem(ElementName = "item")]
        public List<GroupDto> Groups { get; set; }
        [DataMember(Name = "tree"), XmlArray(ElementName = "tree"), XmlArrayItem(ElementName = "item")]
        public List<ItemTreeDto> Tree { get; set; }
        [DataMember(Name = "type"), XmlElement(ElementName = "type")]
        public string Type { get; set; }
        [DataMember(Name = "version"), XmlElement(ElementName = "version")]
        public string Version { get; set; }
    }
}
