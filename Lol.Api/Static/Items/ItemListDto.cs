﻿using Lol.Api.Toolkit;
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
        [DataMember(Name="basic")]
        public BasicDataDto Basic { get; set; }
        [DataMember(Name = "data")]
        public Dictionary<string,ItemDto> Data { get; set; }
        [DataMember(Name = "groups")]
        public List<GroupDto> Groups { get; set; }
        [DataMember(Name = "tree")]
        public List<ItemTreeDto> Tree { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "version")]
        public string Version { get; set; }
    }
}
