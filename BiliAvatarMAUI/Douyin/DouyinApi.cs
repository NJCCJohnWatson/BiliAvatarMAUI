using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BiliAvatarMAUI.Douyin
{
    public class DouyinApi
    {
        HttpClient _client = new HttpClient();

        public HttpClient Client { get => _client; set => _client = value; }
        public FileIO Fs { get => fs; set => fs = value; }
        internal WebIO WebIO { get => webIO; set => webIO = value; }

        FileIO fs = new FileIO();
        WebIO webIO = new WebIO();
        string api_link_video = "https://www.iesdouyin.com/web/api/v2/aweme/iteminfo/?item_ids=";

        public async Task<bool> DownloadVideo(string url, string filepath)
        {
            string error = string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    var resps = await WebIO.GetUrl(url);
                    var orginUrl = resps.StatusCode.ToString().Equals("OK")
                                    ? (resps.RequestMessage is not null ? resps.RequestMessage.RequestUri : null)
                                    : null;
                    var videoBytes = await Client.GetByteArrayAsync(orginUrl);
                    await Fs.WriteBinaryToFile(filepath, videoBytes);
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

        public async Task<WebApiV2ByID> GetVideoInfoByApi(string shareCode)
        {
            var url = GetUrlFromShareCode(shareCode);
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }
            else
            {
                //获取视频ID
                var videoId = await GetVideoIdFromUrl(url);
                //构建视频API链接
                var videoApiUrl = api_link_video + videoId;
                //获取返回字符串
                var responseStr = await Client.GetStringAsync(videoApiUrl);
                var apijson = System.Text.Json.JsonSerializer.Deserialize<WebApiV2ByID>(responseStr);
                return apijson;
            }
        }
        public string GetUrlFromShareCode(string shareCode)
        {
            Regex geturl = new Regex(@"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})");
            if (geturl.Match(shareCode).Success)
            {
                return geturl.Match(shareCode).Value;
            }
            else
            {
                return "";
            }
        }
        public async Task<string> GetVideoIdFromUrl(string url)
        {
            string videoId = string.Empty;
            var res = await WebIO.GetUrl(url);
            //三目用的好，逻辑死得早
            var orginUrl = res.StatusCode.ToString().Equals("OK")
                ? (res.RequestMessage is not null ? res.RequestMessage.RequestUri : null)
                : null;
            if (orginUrl != null)
            {
                var pathUrl = orginUrl.AbsolutePath;
                var pathparaList = pathUrl.Split('/').ToList();
                pathparaList = pathparaList.Where(p => !string.IsNullOrEmpty(p)).ToList();
                videoId = pathparaList.Last();
            }
            return videoId;
        }
    }
}
