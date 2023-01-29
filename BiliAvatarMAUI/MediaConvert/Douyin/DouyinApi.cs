using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BiliAvatarMAUI.Douyin;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;

namespace BiliAvatarMAUI.MediaConvert.Douyin
{
    public class DouyinApi
    {
        HttpClient _client = new HttpClient();

        public HttpClient Client { get => _client; set => _client = value; }
        public FileIO Fs { get => fs; set => fs = value; }

        FileIO fs = new FileIO();
        //Old api
        string api_link_video = "https://www.iesdouyin.com/web/api/v2/aweme/iteminfo/?item_ids=";
        //New api from github
        string api_new_link_video = "https://www.iesdouyin.com/aweme/v1/web/aweme/detail/?aweme_id=";
        public async Task<bool> DownloadContent(string url, string filepath)
        {
            string error = string.Empty;
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    var resps = await WebIO.GetUrl(url);
                    var orginUrl = resps.StatusCode.ToString().Equals("OK")
                                    ? resps.RequestMessage is not null ? resps.RequestMessage.RequestUri : null
                                    : null;
                    var videoBytes = await Client.GetByteArrayAsync(orginUrl);
                    await Fs.WriteBinaryToFile(filepath, videoBytes);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public async Task<ApiJsonModelContainer.ApiJsonModel_v1Detail> GetVideoInfoByApi(string shareCode,string apiLink = "")
        {
            //var url = GetUrlFromShareCode(shareCode);
            if (string.IsNullOrEmpty(shareCode))
            {
                return null;
            }
            else
            {
                //获取视频ID
                var videoId = await GetVideoIdFromUrl(shareCode);
                //构建视频API链接
                var videoApiUrl = apiLink + videoId + "&aid=1128&version_name=23.5.0";
                //获取返回字符串;
                Client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Linux; Android 8.0; Pixel 2 Build/OPD3.170816.012) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Mobile Safari/537.36 Edg/87.0.664.66");
                var responseStr = await Client.GetStringAsync(videoApiUrl);
                //解析
                #region Fiddle 
                //var uriBuilder = new UriBuilder("https://www.iesdouyin.com/web/api/v2/aweme/iteminfo/?item_ids=7183307089220046091", "www.iesdouyin.com");
                //var httpClient = new HttpClient();

                //var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uriBuilder.ToString());




                //httpRequestMessage.Headers.Add("Host", "www.iesdouyin.com");
                //httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:108.0) Gecko/20100101 Firefox/108.0");
                //httpRequestMessage.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8");
                //httpRequestMessage.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2");
                //httpRequestMessage.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                //httpRequestMessage.Headers.Add("Connection", "keep-alive");
                //httpRequestMessage.Headers.Add("Cookie", "msToken=89qHbj6AdzSffbf42P-ZeVr6dwIlxxobTkha50OIR-Q0wDRctlfOjWZFPClKWnit5ulTfGv9qj-gbEiFf7YvwNgIQX4OFN2HlNjrzc3JINU=; __ac_nonce=063b1b06500cfcd5d57f6; __ac_signature=_02B4Z6wo00f01LLnuWAAAIDDWEF6y2Pb.3iy1r3AAE8Nff; __ac_referer=__ac_blank; s_v_web_id=verify_lcdkjvgn_j64MJjPv_icKq_4bOM_ADE1_DLfjUoukd4sQ; _tea_utm_cache_2018=undefined");
                //httpRequestMessage.Headers.Add("Upgrade-Insecure-Requests", "1");
                //httpRequestMessage.Headers.Add("Sec-Fetch-Dest", "document");
                //httpRequestMessage.Headers.Add("Sec-Fetch-Mode", "navigate");
                //httpRequestMessage.Headers.Add("Sec-Fetch-Site", "none");
                //httpRequestMessage.Headers.Add("Sec-Fetch-User", "?1");


                //var message = new HttpRequestMessage(HttpMethod.Post, videoApiUrl);
                //var httpResponseMessage = httpClient.PostAsync();

                //var httpContent = httpResponseMessage.Content;
                //string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                #endregion

                var apijson = System.Text.Json.JsonSerializer.Deserialize<ApiJsonModelContainer.ApiJsonModel_v1Detail>(responseStr);
                return apijson;


            }
        }
        public static string GetUrlFromShareCode(string shareCode)
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
                ? res.RequestMessage is not null ? res.RequestMessage.RequestUri : null
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
