using Lol.Api.Static.Champion;
using Lol.Api.Static.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;

namespace Lol.Itemsets.Models
{
    public class ChampionModel
    {
        private static Dictionary<string, ChampionDto> _items = null;

        public static Dictionary<string, ChampionDto> Champions
        {
            get
            {
                if (_items == null)
                {
                    _items = new Dictionary<string, ChampionDto>();
                    var adapter = new StaticJsonAdapter(HttpContext.Current.Server.MapPath("~/Content"));
                    var result = adapter.ListChampions("euw", CultureString, ApiKey);
                    _items = result.Data;
                }
                return _items;
            }
        }

        private static string CultureString
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.Name.Replace('-', '_');
            }
        }

        public static string ApiKey { get { return WebConfigurationManager.AppSettings["ApiKey"]; } }
    }
}