using Lol.Api.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Lol.Api.Static
{
    public class StaticServiceAdapter : Lol.Api.Toolkit.WcfServiceClient<IStaticService>, IStaticService
    {
        public StaticServiceAdapter()
            : base(new WebHttpBinding { Security = new WebHttpSecurity { Mode = WebHttpSecurityMode.Transport, Transport = new HttpTransportSecurity { ClientCredentialType = HttpClientCredentialType.None } }, MaxReceivedMessageSize = int.MaxValue }, new EndpointAddress("https://global.api.pvp.net/api/lol/static-data")) { this.Endpoint.EndpointBehaviors.Add(new WebHttpBehavior()); }
        public StaticServiceAdapter(Binding binding, EndpointAddress address) : base(binding, address) { }

        public Items.ItemListDto ListItems(string region, string locale, string apikey)
        {
            return base.Channel.ListItems(region, locale, apikey);
        }

        public Champion.ChampionListDto ListChampions(string region, string locale, string apikey)
        {
            return base.Channel.ListChampions(region, locale, apikey);
        }
    }
}
