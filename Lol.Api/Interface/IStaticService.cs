using Lol.Api.Static.Champion;
using Lol.Api.Static.Items;
using Lol.Api.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Lol.Api.Interface
{
    [ServiceContract]
    public interface IStaticService
    {
        [OperationContract, JsonBehavior(ResultType = typeof(ItemListDto))]
        [WebInvoke(
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "/{region}/v1.2/item?locale={locale}&itemListData=all&api_key={apikey}")]
        ItemListDto ListItems(string region, string locale, string apikey);

        [OperationContract, JsonBehavior(ResultType = typeof(ChampionListDto))]
        [WebInvoke(
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Xml,
            UriTemplate = "/{region}/v1.2/champion?locale={locale}&itemListData=all&api_key={apikey}")]
        ChampionListDto ListChampions(string region, string locale, string apikey);
    }
}
