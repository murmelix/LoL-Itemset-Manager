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
    public class BasicDataDto
    {
        [DataMember(Name = "colloq"), XmlElement(ElementName = "colloq")]
        public string Colloq { get; set; }
        [DataMember(Name = "consumeOnFull"), XmlElement(ElementName = "consumeOnFull")]
        public bool ConsumeOnFull { get; set; }
        [DataMember(Name = "consumed"), XmlElement(ElementName = "consumed")]
        public bool Consumed { get; set; }
        [DataMember(Name = "depth"), XmlElement(ElementName = "depth")]
        public int Depth { get; set; }
        [DataMember(Name = "description"), XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [DataMember(Name = "from"), XmlArray(ElementName = "from"), XmlArrayItem(ElementName = "item")]
        public List<string> From { get; set; }
        [DataMember(Name = "gold"), XmlElement(ElementName = "gold")]
        public GoldDto Gold { get; set; }
        [DataMember(Name = "group"), XmlElement(ElementName = "group")]
        public string Group { get; set; }
        [DataMember(Name = "hideFromAll"), XmlElement(ElementName = "hideFromAll")]
        public bool HideFromAll { get; set; }
        [DataMember(Name = "id"), XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [DataMember(Name = "image"), XmlElement(ElementName = "image")]
        public ImageDto Image { get; set; }
        [DataMember(Name = "inStore"), XmlElement(ElementName = "inStore")]
        public bool InStore { get; set; }
        [DataMember(Name = "into"), XmlArray(ElementName = "into"), XmlArrayItem(ElementName = "item")]
        public List<string> Into { get; set; }
        [DataMember(Name = "maps"), XmlArray(ElementName = "maps"), XmlArrayItem(ElementName = "item")]
        public List<string> Maps { get; set; }
        [DataMember(Name = "name"), XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [DataMember(Name = "plaintext"), XmlElement(ElementName = "plaintext")]
        public string Plaintext { get; set; }
        [DataMember(Name = "requiredChampion"), XmlElement(ElementName = "requiredChampion")]
        public string RequiredChampion { get; set; }
        [DataMember(Name = "rune"), XmlElement(ElementName = "rune")]
        public MetaDataDto Rune { get; set; }
        [DataMember(Name = "sanitizedDescription"), XmlElement(ElementName = "sanitizedDescription")]
        public string SanitizedDescription { get; set; }
        [DataMember(Name = "specialRecipe"), XmlElement(ElementName = "specialRecipe")]
        public int SpecialRecipe { get; set; }
        [DataMember(Name = "stacks"), XmlElement(ElementName = "stacks")]
        public int Stacks { get; set; }
        [DataMember(Name = "stats"), XmlElement(ElementName = "stats")]
        public BasicDataStatsDto Stats { get; set; }
        [DataMember(Name = "tags"), XmlArray(ElementName = "tags"), XmlArrayItem(ElementName = "item")]
        public List<string> Tags { get; set; }
    }
}
