using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BiliAvatarMAUI.Douyin
{
    public class DouyinApi
    {
        HttpClient _client = new HttpClient();

        public HttpClient Client { get => _client; set => _client = value; }

        public void DownloadVideo(string url,string filepath)
        {
            var resp = Client.GetByteArrayAsync(url).Result;           
            FileIO.WriteBinaryToFile(filepath, resp);
        }

        public dynamic GetVideoInfoByApi(string url)
        {
            var responseStr = Client.GetStringAsync(url).Result;
            var converter = new ExpandoObjectConverter();
            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(responseStr, converter);
            return obj;
        }
    }
}
