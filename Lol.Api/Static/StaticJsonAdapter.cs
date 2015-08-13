using Lol.Api.Interface;
using Lol.Api.Static.Champion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lol.Api.Static.Items
{
    public class StaticJsonAdapter : IStaticService
    {
        private string _cachePath;

        public StaticJsonAdapter(string chachePath)
        {
            _cachePath = chachePath;
        }

        public ItemListDto ListItems(string region, string locale, string apikey)
        {
            string path = Path.Combine(_cachePath, region, locale, "items.json");
            string jsonFromCache = GetJsonFromCache(path);
            if (jsonFromCache != null)
            {
                return JsonConvert.DeserializeObject<ItemListDto>(jsonFromCache);
            }
            lock (path)
            {
                var wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                using (wc)
                {
                    var json = wc.DownloadString(string.Format("https://global.api.pvp.net/api/lol/static-data/{2}/v1.2/item?locale={0}&itemListData=all&api_key={1}", locale, apikey, region));
                    using (var sw = new StreamWriter(path, false, Encoding.UTF8))
                        sw.Write(json);
                    return JsonConvert.DeserializeObject<ItemListDto>(json, new JsonSerializerSettings { Culture = Thread.CurrentThread.CurrentUICulture, });
                }
            }
        }

        public ChampionListDto ListChampions(string region, string locale, string apikey)
        {
            string path = Path.Combine(_cachePath, region, locale, "champions.json");
            string jsonFromCache = GetJsonFromCache(path);
            if (jsonFromCache != null)
            {
                return JsonConvert.DeserializeObject<ChampionListDto>(jsonFromCache);
            }
            lock (path)
            {
                var wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                using (wc)
                {
                    var json = wc.DownloadString(string.Format("https://global.api.pvp.net/api/lol/static-data/{2}/v1.2/champion?locale={0}&champData=all&api_key={1}", locale, apikey, region));
                    using (var sw = new StreamWriter(path, false, Encoding.UTF8))
                        sw.Write(json);
                    return JsonConvert.DeserializeObject<ChampionListDto>(json, new JsonSerializerSettings { Culture = Thread.CurrentThread.CurrentUICulture, });
                }
            }
        }

        private string GetJsonFromCache(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path, Encoding.UTF8))
                {
                    return sr.ReadToEnd();
                }
            }
            return null;
        }
    }
}
