using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliAvatarMAUI.Douyin
{
    public static class MediaType
    {
        public enum SourceSiteType
        {
            Unknown = 0,
            Douyin = 1,
            Bilibli = 2,
            Twitter = 3,
            TikTok = 5
        }
        public static SourceSiteType SwitchSiteTypeByLink(string link)
        {
            if (string.IsNullOrEmpty(link))
            {
                return SourceSiteType.Unknown;
            }
            else
            {
                if (link.Contains("bili"))
                {
                    return SourceSiteType.Bilibli;
                }
                else
                {
                    if(link.Contains("douyin"))
                    {
                        return SourceSiteType.Douyin;
                    }
                    else
                    {
                        if(link.Contains("twitter"))
                        {
                            return SourceSiteType.Twitter;
                        }
                        else
                        {
                            if(link.Contains("tiktok"))
                            {
                                return SourceSiteType.TikTok;
                            }
                            else
                            {
                                //TODO Add new site be here
                                return SourceSiteType.Unknown;
                            }
                        }
                    }
                }
            }
        }
    }
}
