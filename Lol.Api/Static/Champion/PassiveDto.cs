using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lol.Api.Static.Champion
{
    [DataContract]
    public class PassiveDto
    {
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "image")]
        public ImageDto Image { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "sanitizedDescription")]
        public string SanitizedDescription { get; set; }
    }
}
