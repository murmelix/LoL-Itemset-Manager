﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lol.Api.Static.Items
{
    [DataContract]
    public class ItemTreeDto
    {
        [DataMember(Name = "header"), XmlElement(ElementName = "header")]
        public string Header { get; set; }
        [DataMember(Name = "tags"), XmlArray(ElementName = "tags"), XmlArrayItem(ElementName = "item")]
        public List<string> Tags { get; set; }
    }
}