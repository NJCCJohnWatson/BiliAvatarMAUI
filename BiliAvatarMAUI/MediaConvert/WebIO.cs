﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliAvatarMAUI
{
    public static class WebIO
    {//handler.AllowAutoRedirect=false;
        private static HttpClient client = new HttpClient(new HttpClientHandler()
        {
            AllowAutoRedirect = true
        });
        public static HttpClient Client { get => client; set => client = value; }

        public static async Task<HttpResponseMessage> GetUrl(string url)
        {
            Client.DefaultRequestHeaders.Add("user-agent"
                  , "'Mozilla/5.0 (Linux; Android 8.0; Pixel 2 Build/OPD3.170816.012) " +
                  "AppleWebKit/537.36 (KHTML, like Gecko) " +
                  "Chrome/87.0.4280.88 Mobile Safari/537.36 Edg/87.0.664.66");
            var resp = await Client.GetAsync(url);
            return resp;
        }
        public static async Task<HttpResponseMessage> GetUrl(string url, string headerName, string headerValue)
        {
            Client.DefaultRequestHeaders.Add(headerName
                  , headerValue);
            var resp = await Client.GetAsync(url);
            return resp;
        }
        public static Uri ReturnActualUrl(HttpResponseMessage res)
        {
            var orginUrl = res.StatusCode.ToString().Equals("OK")
                                ? (res.RequestMessage is not null ? res.RequestMessage.RequestUri : null)
                                : null;
            return orginUrl;
        }
    }
}
