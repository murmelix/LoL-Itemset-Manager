using Lol.Api.Static;
using Lol.Api.Static.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;

namespace Lol.Itemsets.Models
{
    public class ItemModel
    {
        private static Dictionary<int, ItemDto> _items = null;

        public static Dictionary<int, ItemDto> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new Dictionary<int, ItemDto>();
                    using (var adapter = new StaticServiceAdapter())
                    {
                        var result = adapter.ListItems("euw", "en_US", ApiKey);
                        foreach (var i in result.Data)
                            _items.Add(i.Id, i);
                    }
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