using Lol.Api.Static.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lol.Api.Static
{
    [DataContract]
    public class BlockDto
    {
        [DataMember(Name = "items")]
        public List<BlockItemDto> Items { get; set; }
        [DataMember(Name = "recMath")]
        public bool RecMath { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
