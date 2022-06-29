using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliAvatarMAUI.Douyin
{

    public class WebApiV2ByID
    {
        public object[] filter_list { get; set; }
        public Extra extra { get; set; }
        public int status_code { get; set; }
        public Item_List[] item_list { get; set; }
    }

    public class Extra
    {
        public long now { get; set; }
        public string logid { get; set; }
    }

    public class Item_List
    {
        public int create_time { get; set; }
        public Video video { get; set; }
        public object geofencing { get; set; }
        public bool is_live_replay { get; set; }
        public images[] images { get; set; }
        public long author_user_id { get; set; }
        public string aweme_id { get; set; }
        public string share_url { get; set; }
        public object comment_list { get; set; }
        public string desc { get; set; }
        public object promotions { get; set; }
        public string forward_id { get; set; }
        public Aweme_Poi_Info aweme_poi_info { get; set; }
        public Cha_List[] cha_list { get; set; }
        public Share_Info share_info { get; set; }
        public int aweme_type { get; set; }
        public Risk_Infos risk_infos { get; set; }
        public int is_preview { get; set; }
        public Author author { get; set; }
        public Music music { get; set; }
        public Statistics statistics { get; set; }
        public object video_text { get; set; }
        public Anchor_Info anchor_info { get; set; }
        public object video_labels { get; set; }
        public object label_top_text { get; set; }
        public object long_video { get; set; }
        public Text_Extra[] text_extra { get; set; }
        public int duration { get; set; }
        public object image_infos { get; set; }
        public long group_id { get; set; }
        public string group_id_str { get; set; }
    }

    public class Video
    {
        public Play_Addr play_addr { get; set; }
        public Cover cover { get; set; }
        public int width { get; set; }
        public Dynamic_Cover dynamic_cover { get; set; }
        public Origin_Cover origin_cover { get; set; }
        public string ratio { get; set; }
        public bool has_watermark { get; set; }
        public object bit_rate { get; set; }
        public int duration { get; set; }
        public string vid { get; set; }
        public int height { get; set; }
    }

    public class Play_Addr
    {
        public string[] url_list { get; set; }
        public string uri { get; set; }
    }

    public class Cover
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
    }

    public class Dynamic_Cover
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
    }

    public class Origin_Cover
    {
        public string[] url_list { get; set; }
        public string uri { get; set; }
    }

    public class Aweme_Poi_Info
    {
        public string tag { get; set; }
        public Icon icon { get; set; }
        public string poi_name { get; set; }
        public string type_name { get; set; }
    }

    public class Icon
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
    }

    public class Share_Info
    {
        public string share_weibo_desc { get; set; }
        public string share_desc { get; set; }
        public string share_title { get; set; }
    }

    public class Risk_Infos
    {
        public bool warn { get; set; }
        public int type { get; set; }
        public string content { get; set; }
        public int reflow_unplayable { get; set; }
    }

    public class Author
    {
        public string uid { get; set; }
        public Avatar_Larger avatar_larger { get; set; }
        public object mix_info { get; set; }
        public Avatar_Thumb avatar_thumb { get; set; }
        public object geofencing { get; set; }
        public object type_label { get; set; }
        public object card_entries { get; set; }
        public string nickname { get; set; }
        public string signature { get; set; }
        public Avatar_Medium avatar_medium { get; set; }
        public object followers_detail { get; set; }
        public string short_id { get; set; }
        public int follow_status { get; set; }
        public string unique_id { get; set; }
        public object platform_sync_info { get; set; }
        public object policy_version { get; set; }
    }

    public class Avatar_Larger
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
    }

    public class Avatar_Thumb
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
    }

    public class Avatar_Medium
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
    }

    public class Music
    {
        public string mid { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public Cover_Large cover_large { get; set; }
        public Cover_Medium cover_medium { get; set; }
        public Play_Url play_url { get; set; }
        public long id { get; set; }
        public Cover_Thumb cover_thumb { get; set; }
        public int duration { get; set; }
        public object position { get; set; }
        public int status { get; set; }
        public Cover_Hd cover_hd { get; set; }
    }

    public class Cover_Large
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
    }

    public class Cover_Medium
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
    }

    public class Play_Url
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
    }

    public class Cover_Thumb
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
    }

    public class Cover_Hd
    {
        public string[] url_list { get; set; }
        public string uri { get; set; }
    }

    public class Statistics
    {
        public string aweme_id { get; set; }
        public int comment_count { get; set; }
        public int digg_count { get; set; }
        public int play_count { get; set; }
        public int share_count { get; set; }
    }

    public class Anchor_Info
    {
        public string id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
    }

    public class Cha_List
    {
        public int view_count { get; set; }
        public string cha_name { get; set; }
        public string desc { get; set; }
        public int user_count { get; set; }
        public object connect_music { get; set; }
        public int type { get; set; }
        public Cover_Item cover_item { get; set; }
        public string cid { get; set; }
        public string hash_tag_profile { get; set; }
        public bool is_commerce { get; set; }
    }

    public class Cover_Item
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
    }

    public class Text_Extra
    {
        public string hashtag_name { get; set; }
        public long hashtag_id { get; set; }
        public int start { get; set; }
        public int end { get; set; }
        public string user_id { get; set; }
        public int type { get; set; }
    }

    public class images
    {
        public string uri { get; set; }
        public string[] url_list { get; set; }
        public string[] download_url_list { get; set; }
        public int height { get; set; }
        public int width { get; set; }
    }


}
