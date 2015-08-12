using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lol.Api.Static.Items
{
    [DataContract]
    public class ItemDto : BasicDataDto
    {
        public bool IsBilgewater { get { return Tags.Any(x => x == "Bilgewater"); } }
    }
}
