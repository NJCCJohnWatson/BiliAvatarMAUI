using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BiliAvatarMAUI.MediaConvert.Bilibili.BilibiliApi.DynamicCardContain;

namespace BiliAvatarMAUI.MediaConvert.Bilibili
{
    public class BilibiliApi
    {
        public class dynamicMainInfo
        {
            /// <summary>
            /// 上传者Id
            /// </summary>
            public string authorId { get; set; }
            /// <summary>
            /// 上传者名称
            /// </summary>
            public string authorName { get; set; }
            /// <summary>
            /// 动态Id
            /// </summary>
            public string dynamicId { get; set; }
            /// <summary>
            /// 图片地址
            /// </summary>
            public string[] picUris { get; set; }

        }
        public static class BiliQueryApi
        {
            private static string get_dynamic_detail = "https://api.vc.bilibili.com/dynamic_svr/v1/dynamic_svr/get_dynamic_detail?dynamic_id=";
            static UriBuilder api_vc_bilibili = new UriBuilder();


            public static string Dynamic_detail { get => get_dynamic_detail; set => get_dynamic_detail = value; }
        }
        public class Dynamic
        {
            public class Dynamic_Detail_Model
            {
                public long code { get; set; }
                public string msg { get; set; }
                public string message { get; set; }
                public Data data { get; set; }
            }

            public class Data
            {
                public Card card { get; set; }
                public long result { get; set; }
                public Attentions attentions { get; set; }
                public long _gt_ { get; set; }
            }

            public class Card
            {
                public Desc desc { get; set; }
                public string card { get; set; }
                public string extend_json { get; set; }
                public Display display { get; set; }
            }

            public class Desc
            {
                public long uid { get; set; }
                public long type { get; set; }
                public long rid { get; set; }
                public long acl { get; set; }
                public long view { get; set; }
                public long repost { get; set; }
                public long comment { get; set; }
                public long like { get; set; }
                public long is_liked { get; set; }
                public long dynamic_id { get; set; }
                public long timestamp { get; set; }
                public long pre_dy_id { get; set; }
                public long orig_dy_id { get; set; }
                public long orig_type { get; set; }
                public User_Profile user_profile { get; set; }
                public long uid_type { get; set; }
                public long stype { get; set; }
                public long r_type { get; set; }
                public long inner_id { get; set; }
                public long status { get; set; }
                public string dynamic_id_str { get; set; }
                public string pre_dy_id_str { get; set; }
                public string orig_dy_id_str { get; set; }
                public string rid_str { get; set; }
            }

            public class User_Profile
            {
                public Info info { get; set; }
                public Card1 card { get; set; }
                public Vip vip { get; set; }
                public Pendant pendant { get; set; }
                public string rank { get; set; }
                public string sign { get; set; }
                public Level_Info level_info { get; set; }
            }

            public class Info
            {
                public long uid { get; set; }
                public string uname { get; set; }
                public string face { get; set; }
                public long face_nft { get; set; }
            }

            public class Card1
            {
                public Official_Verify official_verify { get; set; }
            }

            public class Official_Verify
            {
                public long type { get; set; }
                public string desc { get; set; }
            }

            public class Vip
            {
                public long vipType { get; set; }
                public long vipDueDate { get; set; }
                public long vipStatus { get; set; }
                public long themeType { get; set; }
                public Label label { get; set; }
                public long avatar_subscript { get; set; }
                public string nickname_color { get; set; }
                public long role { get; set; }
                public string avatar_subscript_url { get; set; }
            }

            public class Label
            {
                public string path { get; set; }
                public string text { get; set; }
                public string label_theme { get; set; }
                public string text_color { get; set; }
                public long bg_style { get; set; }
                public string bg_color { get; set; }
                public string border_color { get; set; }
            }

            public class Pendant
            {
                public long pid { get; set; }
                public string name { get; set; }
                public string image { get; set; }
                public long expire { get; set; }
                public string image_enhance { get; set; }
                public string image_enhance_frame { get; set; }
            }

            public class Level_Info
            {
                public long current_level { get; set; }
            }

            public class Display
            {
                public Emoji_Info emoji_info { get; set; }
                public Relation relation { get; set; }
            }

            public class Emoji_Info
            {
                public Emoji_Details[] emoji_details { get; set; }
            }

            public class Emoji_Details
            {
                public string emoji_name { get; set; }
                public long id { get; set; }
                public long package_id { get; set; }
                public long state { get; set; }
                public long type { get; set; }
                public long attr { get; set; }
                public string text { get; set; }
                public string url { get; set; }
                public Meta meta { get; set; }
                public long mtime { get; set; }
            }

            public class Meta
            {
                public long size { get; set; }
            }

            public class Relation
            {
                public long status { get; set; }
                public long is_follow { get; set; }
                public long is_followed { get; set; }
            }

            public class Attentions
            {
                public long[] uids { get; set; }
            }
        }

        public class DynamicCard
        {


            public class DynamicExtendCard
            {
                public User user { get; set; }
                public Item item { get; set; }
                public string origin { get; set; }
                public string origin_extend_json { get; set; }
                public Origin_User origin_user { get; set; }
            }

            public class User
            {
                public long uid { get; set; }
                public string uname { get; set; }
                public string face { get; set; }
            }

            public class Item
            {
                public string at_control { get; set; }
                public string category { get; set; }
                public string description { get; set; }
                public long id { get; set; }
                public long is_fav { get; set; }
                public Picture[] pictures { get; set; }
                public long pictures_count { get; set; }
                public long reply { get; set; }
                public object[] role { get; set; }
                public Settings settings { get; set; }
                public object[] source { get; set; }
                public string title { get; set; }
                public long upload_time { get; set; }

            }

            public class Picture
            {
                public long img_height { get; set; }
                public float img_size { get; set; }
                public string img_src { get; set; }
                public object img_tags { get; set; }
                public long img_width { get; set; }
            }
            public class Origin_User
            {
                public Info info { get; set; }
                public Card card { get; set; }
                public Vip vip { get; set; }
                public Pendant pendant { get; set; }
                public string rank { get; set; }
                public string sign { get; set; }
                public Level_Info level_info { get; set; }
            }

            public class Info
            {
                public long uid { get; set; }
                public string uname { get; set; }
                public string face { get; set; }
                public long face_nft { get; set; }
            }

            public class Card
            {
                public Official_Verify official_verify { get; set; }
            }

            public class Official_Verify
            {
                public long type { get; set; }
                public string desc { get; set; }
            }

            public class Vip
            {
                public long vipType { get; set; }
                public long vipDueDate { get; set; }
                public long vipStatus { get; set; }
                public long themeType { get; set; }
                public Label label { get; set; }
                public long avatar_subscript { get; set; }
                public string nickname_color { get; set; }
                public long role { get; set; }
                public string avatar_subscript_url { get; set; }
            }

            public class Label
            {
                public string path { get; set; }
                public string text { get; set; }
                public string label_theme { get; set; }
                public string text_color { get; set; }
                public long bg_style { get; set; }
                public string bg_color { get; set; }
                public string border_color { get; set; }
            }

            public class Pendant
            {
                public long pid { get; set; }
                public string name { get; set; }
                public string image { get; set; }
                public long expire { get; set; }
                public string image_enhance { get; set; }
                public string image_enhance_frame { get; set; }
            }

            public class Level_Info
            {
                public long current_level { get; set; }
            }
        }
        public class DynamicCardContain
        {

            public class DynamicCardOrgin
            {
                public Item item { get; set; }
                public User user { get; set; }
            }

            public class Item
            {
                public string at_control { get; set; }
                public string category { get; set; }
                public string description { get; set; }
                public long id { get; set; }
                public long is_fav { get; set; }
                public Picture[] pictures { get; set; }
                public long pictures_count { get; set; }
                public long reply { get; set; }
                public object[] role { get; set; }
                public Settings settings { get; set; }
                public object[] source { get; set; }
                public string title { get; set; }
                public long upload_time { get; set; }
            }

            public class Settings
            {
                public string copy_forbidden { get; set; }
            }

            public class Picture
            {
                public long img_height { get; set; }
                public float img_size { get; set; }
                public string img_src { get; set; }
                public object img_tags { get; set; }
                public long img_width { get; set; }
            }

            public class User
            {
                public string head_url { get; set; }
                public string name { get; set; }
                public long uid { get; set; }
                public Vip vip { get; set; }
            }

            public class Vip
            {
                public long avatar_subscript { get; set; }
                public long due_date { get; set; }
                public Label label { get; set; }
                public string nickname_color { get; set; }
                public long status { get; set; }
                public long theme_type { get; set; }
                public long type { get; set; }
                public long vip_pay_type { get; set; }
            }

            public class Label
            {
                public string label_theme { get; set; }
                public string path { get; set; }
                public string text { get; set; }
            }

        }
    }
}
