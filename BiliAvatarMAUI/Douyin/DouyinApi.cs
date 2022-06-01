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
        public FileSys Fs { get => fs; set => fs = value; }

        FileSys fs = new FileSys();

        public async Task<bool> DownloadVideo(string url, string filepath)
        {
            string error = string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    var resp = await Client.GetByteArrayAsync(url);
                    //FileIO.WriteBinaryToFile(filepath, resp);
                    await Fs.WriteBinaryToFile(filepath, resp);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public async Task<dynamic> GetVideoInfoByApi(string url)
        {
            var responseStr = await Client.GetStringAsync(url);
            var converter = new ExpandoObjectConverter();
            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(responseStr, converter);
            return obj;
        }
    }
}
