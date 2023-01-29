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
    public class ApiJsonModelContainer
    {

        public class ApiJsonModel_v1Detail
        {
            public Aweme_Detail aweme_detail { get; set; }
            public Log_Pb log_pb { get; set; }
            public int status_code { get; set; }
        }

        public class Aweme_Detail
        {
            public object anchors { get; set; }
            public Author author { get; set; }
            public int author_mask_tag { get; set; }
            public long author_user_id { get; set; }
            public Aweme_Control aweme_control { get; set; }
            public string aweme_id { get; set; }
            public int aweme_type { get; set; }
            public object challenge_position { get; set; }
            public object chapter_list { get; set; }
            public int collect_stat { get; set; }
            public long comment_gid { get; set; }
            public object comment_list { get; set; }
            public Comment_Permission_Info comment_permission_info { get; set; }
            public object commerce_config_data { get; set; }
            public string common_bar_info { get; set; }
            public string component_info_v2 { get; set; }
            public object cover_labels { get; set; }
            public int create_time { get; set; }
            public string desc { get; set; }
            public Descendants descendants { get; set; }
            public Digg_Lottie digg_lottie { get; set; }
            public int disable_relation_bar { get; set; }
            public object dislike_dimension_list { get; set; }
            public bool duet_aggregate_in_music_tab { get; set; }
            public int duration { get; set; }
            public object[] geofencing { get; set; }
            public object geofencing_regions { get; set; }
            public string group_id { get; set; }
            public object hybrid_label { get; set; }
            public Image_Album_Music_Info image_album_music_info { get; set; }
            public object image_infos { get; set; }
            public object image_list { get; set; }
            public object images { get; set; }
            public object img_bitrate { get; set; }
            public Impression_Data impression_data { get; set; }
            public object interaction_stickers { get; set; }
            public bool is_ads { get; set; }
            public int is_collects_selected { get; set; }
            public bool is_duet_sing { get; set; }
            public bool is_image_beat { get; set; }
            public bool is_life_item { get; set; }
            public int is_story { get; set; }
            public int is_top { get; set; }
            public Item_Warn_Notification item_warn_notification { get; set; }
            public object label_top_text { get; set; }
            public object long_video { get; set; }
            public Music music { get; set; }
            public object nickname_position { get; set; }
            public object origin_comment_ids { get; set; }
            public object[] origin_text_extra { get; set; }
            public object original_images { get; set; }
            public object packed_clips { get; set; }
            public Photo_Search_Entrance photo_search_entrance { get; set; }
            public object position { get; set; }
            public string preview_title { get; set; }
            public int preview_video_status { get; set; }
            public object[] promotions { get; set; }
            public int rate { get; set; }
            public string region { get; set; }
            public object relation_labels { get; set; }
            public Search_Impr1 search_impr { get; set; }
            public Series_Paid_Info series_paid_info { get; set; }
            public Share_Info1 share_info { get; set; }
            public string share_url { get; set; }
            public bool should_open_ad_report { get; set; }
            public Show_Follow_Button show_follow_button { get; set; }
            public object social_tag_list { get; set; }
            public object standard_bar_info_list { get; set; }
            public Statistics statistics { get; set; }
            public Status status { get; set; }
            public Text_Extra[] text_extra { get; set; }
            public object uniqid_position { get; set; }
            public int user_digged { get; set; }
            public Video video { get; set; }
            public object video_labels { get; set; }
            public Video_Tag[] video_tag { get; set; }
            public object[] video_text { get; set; }
            public Wanna_Tag wanna_tag { get; set; }
        }

        public class Author
        {
            public Avatar_Thumb avatar_thumb { get; set; }
            public object cf_list { get; set; }
            public int close_friend_type { get; set; }
            public int contacts_status { get; set; }
            public object contrail_list { get; set; }
            public Cover_Url[] cover_url { get; set; }
            public int create_time { get; set; }
            public string custom_verify { get; set; }
            public object data_label_list { get; set; }
            public object endorsement_info_list { get; set; }
            public string enterprise_verify_reason { get; set; }
            public int favoriting_count { get; set; }
            public int follow_status { get; set; }
            public int follower_count { get; set; }
            public object follower_list_secondary_information_struct { get; set; }
            public int follower_status { get; set; }
            public int following_count { get; set; }
            public object im_role_ids { get; set; }
            public bool is_ad_fake { get; set; }
            public bool is_blocked_v2 { get; set; }
            public bool is_blocking_v2 { get; set; }
            public int is_cf { get; set; }
            public int max_follower_count { get; set; }
            public string nickname { get; set; }
            public object not_seen_item_id_list { get; set; }
            public object not_seen_item_id_list_v2 { get; set; }
            public object offline_info_list { get; set; }
            public object personal_tag_list { get; set; }
            public bool prevent_download { get; set; }
            public string risk_notice_text { get; set; }
            public string sec_uid { get; set; }
            public int secret { get; set; }
            public Share_Info share_info { get; set; }
            public string short_id { get; set; }
            public string signature { get; set; }
            public object signature_extra { get; set; }
            public object special_people_labels { get; set; }
            public int status { get; set; }
            public object text_extra { get; set; }
            public int total_favorited { get; set; }
            public string uid { get; set; }
            public string unique_id { get; set; }
            public int user_age { get; set; }
            public bool user_canceled { get; set; }
            public object user_permissions { get; set; }
            public int verification_type { get; set; }
        }

        public class Avatar_Thumb
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Share_Info
        {
            public string share_desc { get; set; }
            public string share_desc_info { get; set; }
            public Share_Qrcode_Url share_qrcode_url { get; set; }
            public string share_title { get; set; }
            public string share_title_myself { get; set; }
            public string share_title_other { get; set; }
            public string share_url { get; set; }
            public string share_weibo_desc { get; set; }
        }

        public class Share_Qrcode_Url
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Cover_Url
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Aweme_Control
        {
            public bool can_comment { get; set; }
            public bool can_forward { get; set; }
            public bool can_share { get; set; }
            public bool can_show_comment { get; set; }
        }

        public class Comment_Permission_Info
        {
            public bool can_comment { get; set; }
            public int comment_permission_status { get; set; }
            public bool item_detail_entry { get; set; }
            public bool press_entry { get; set; }
            public bool toast_guide { get; set; }
        }

        public class Descendants
        {
            public string notify_msg { get; set; }
            public string[] platforms { get; set; }
        }

        public class Digg_Lottie
        {
            public int can_bomb { get; set; }
            public string lottie_id { get; set; }
        }

        public class Image_Album_Music_Info
        {
            public int begin_time { get; set; }
            public int end_time { get; set; }
            public int volume { get; set; }
        }

        public class Impression_Data
        {
            public long[] group_id_list_a { get; set; }
            public long[] group_id_list_b { get; set; }
            public object similar_id_list_a { get; set; }
            public object similar_id_list_b { get; set; }
        }

        public class Item_Warn_Notification
        {
            public string content { get; set; }
            public bool show { get; set; }
            public int type { get; set; }
        }

        public class Music
        {
            public string album { get; set; }
            public object artist_user_infos { get; set; }
            public object[] artists { get; set; }
            public int audition_duration { get; set; }
            public string author { get; set; }
            public bool author_deleted { get; set; }
            public object author_position { get; set; }
            public int author_status { get; set; }
            public Avatar_Large avatar_large { get; set; }
            public Avatar_Medium avatar_medium { get; set; }
            public Avatar_Thumb1 avatar_thumb { get; set; }
            public int binded_challenge_id { get; set; }
            public bool can_background_play { get; set; }
            public int collect_stat { get; set; }
            public Cover_Hd cover_hd { get; set; }
            public Cover_Large cover_large { get; set; }
            public Cover_Medium cover_medium { get; set; }
            public Cover_Thumb cover_thumb { get; set; }
            public bool dmv_auto_show { get; set; }
            public int dsp_status { get; set; }
            public int duration { get; set; }
            public int end_time { get; set; }
            public object[] external_song_info { get; set; }
            public string extra { get; set; }
            public long id { get; set; }
            public string id_str { get; set; }
            public bool is_audio_url_with_cookie { get; set; }
            public bool is_commerce_music { get; set; }
            public bool is_del_video { get; set; }
            public bool is_matched_metadata { get; set; }
            public bool is_original { get; set; }
            public bool is_original_sound { get; set; }
            public bool is_pgc { get; set; }
            public bool is_restricted { get; set; }
            public bool is_video_self_see { get; set; }
            public Luna_Info luna_info { get; set; }
            public object lyric_short_position { get; set; }
            public string mid { get; set; }
            public object music_chart_ranks { get; set; }
            public int music_status { get; set; }
            public object musician_user_infos { get; set; }
            public bool mute_share { get; set; }
            public string offline_desc { get; set; }
            public string owner_handle { get; set; }
            public string owner_id { get; set; }
            public string owner_nickname { get; set; }
            public int pgc_music_type { get; set; }
            public Play_Url play_url { get; set; }
            public object position { get; set; }
            public bool prevent_download { get; set; }
            public int prevent_item_download_status { get; set; }
            public int preview_end_time { get; set; }
            public int preview_start_time { get; set; }
            public int reason_type { get; set; }
            public bool redirect { get; set; }
            public string schema_url { get; set; }
            public Search_Impr search_impr { get; set; }
            public string sec_uid { get; set; }
            public int shoot_duration { get; set; }
            public int source_platform { get; set; }
            public int start_time { get; set; }
            public int status { get; set; }
            public object tag_list { get; set; }
            public string title { get; set; }
            public object unshelve_countries { get; set; }
            public int user_count { get; set; }
            public int video_duration { get; set; }
        }

        public class Avatar_Large
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Avatar_Medium
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Avatar_Thumb1
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Cover_Hd
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Cover_Large
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Cover_Medium
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Cover_Thumb
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Luna_Info
        {
            public bool is_luna_user { get; set; }
        }

        public class Play_Url
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string url_key { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Search_Impr
        {
            public string entity_id { get; set; }
        }

        public class Photo_Search_Entrance
        {
            public int ecom_type { get; set; }
        }

        public class Search_Impr1
        {
            public string entity_id { get; set; }
            public string entity_type { get; set; }
        }

        public class Series_Paid_Info
        {
            public int item_price { get; set; }
            public int series_paid_status { get; set; }
        }

        public class Share_Info1
        {
            public string share_desc { get; set; }
            public string share_desc_info { get; set; }
            public string share_link_desc { get; set; }
            public string share_url { get; set; }
        }

        public class Show_Follow_Button
        {
        }

        public class Statistics
        {
            public int admire_count { get; set; }
            public string aweme_id { get; set; }
            public int collect_count { get; set; }
            public int comment_count { get; set; }
            public int digg_count { get; set; }
            public int play_count { get; set; }
            public int share_count { get; set; }
        }

        public class Status
        {
            public bool allow_share { get; set; }
            public string aweme_id { get; set; }
            public bool in_reviewing { get; set; }
            public bool is_delete { get; set; }
            public bool is_prohibited { get; set; }
            public int listen_video_status { get; set; }
            public int part_see { get; set; }
            public int private_status { get; set; }
            public Review_Result review_result { get; set; }
        }

        public class Review_Result
        {
            public int review_status { get; set; }
        }

        public class Video
        {
            public object big_thumbs { get; set; }
            public Bit_Rate[] bit_rate { get; set; }
            public Cover cover { get; set; }
            public Cover_Original_Scale cover_original_scale { get; set; }
            public int duration { get; set; }
            public Dynamic_Cover dynamic_cover { get; set; }
            public int height { get; set; }
            public int is_h265 { get; set; }
            public int is_source_HDR { get; set; }
            public string meta { get; set; }
            public Optimized_Cover optimized_cover { get; set; }
            public Origin_Cover origin_cover { get; set; }
            public Play_Addr play_addr { get; set; }
            public string ratio { get; set; }
            public int width { get; set; }
        }

        public class Cover
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Cover_Original_Scale
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Dynamic_Cover
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Optimized_Cover
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Origin_Cover
        {
            public int height { get; set; }
            public string uri { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Play_Addr
        {
            public int data_size { get; set; }
            public string file_cs { get; set; }
            public string file_hash { get; set; }
            public int height { get; set; }
            public string uri { get; set; }
            public string url_key { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Bit_Rate
        {
            public int FPS { get; set; }
            public string HDR_bit { get; set; }
            public string HDR_type { get; set; }
            public int bit_rate { get; set; }
            public string gear_name { get; set; }
            public int is_bytevc1 { get; set; }
            public int is_h265 { get; set; }
            public Play_Addr1 play_addr { get; set; }
            public int quality_type { get; set; }
        }

        public class Play_Addr1
        {
            public int data_size { get; set; }
            public string file_cs { get; set; }
            public string file_hash { get; set; }
            public int height { get; set; }
            public string uri { get; set; }
            public string url_key { get; set; }
            public string[] url_list { get; set; }
            public int width { get; set; }
        }

        public class Wanna_Tag
        {
        }

        public class Text_Extra
        {
            public int end { get; set; }
            public string hashtag_id { get; set; }
            public string hashtag_name { get; set; }
            public bool is_commerce { get; set; }
            public int start { get; set; }
            public int type { get; set; }
        }

        public class Video_Tag
        {
            public int level { get; set; }
            public int tag_id { get; set; }
            public string tag_name { get; set; }
        }

        public class Log_Pb
        {
            public string impr_id { get; set; }
        }

    }

}
