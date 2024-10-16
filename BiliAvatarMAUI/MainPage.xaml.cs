//using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;
using Microsoft.Maui.Graphics;
using System.Drawing;
using BiliAvatarMAUI.Douyin;
using InvokePlatformCodeDemos.Services;
using BiliAvatarMAUI.Services.PartialMethods;
using BiliAvatarMAUI.Services;
using BiliAvatarMAUI.MediaConvert.Douyin;
using BiliAvatarMAUI.MediaConvert.Bilibili;
using System.Text.Json;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.VisualBasic;
using System.Text.Json.Serialization;
using FileSystem = Microsoft.Maui.Storage.FileSystem;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Storage;
using Tomlyn;

namespace BiliAvatarMAUI;

public partial class MainPage : ContentPage
{
    int count = 0;

    enum ContentType
    {
        Pictures = 2, Video = 4
    };
    DouyinApi douyin = new DouyinApi();
    bool IsAndroid() =>
    DeviceInfo.Current.Platform == DevicePlatform.Android;
    bool IsWindows() =>
        DeviceInfo.Current.Platform == DevicePlatform.WinUI;
    bool IsiOS() =>
        DeviceInfo.Current.Platform == DevicePlatform.iOS;
    string savingPath = String.Empty;
    //savingPath= @"/storage/emulated/0/Pictures/DouyinDownload";
    public string apiUri = string.Empty;

    public MainPage()
    {
        InitializeComponent();
        GetConfigApi();
        //suckLabel.BindingContext = sld_BitchDeg;
        //suckLabel.SetBinding(Label.RotationProperty, "Value");
        //lbl_BitchyDeg.BindingContext = sld_BitchDeg;
        //lbl_BitchyDeg.SetBinding(Label.TextProperty, "Value");
        //imgDy.Source = "dage.jpg";
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        CounterLabel.Text = $"Current count: {count}";

        SemanticScreenReader.Announce(CounterLabel.Text);
        LoadImageUrl("https://n.sinaimg.cn/ent/transform/616/w630h786/20191213/2540-ikrsess4946544.jpg", img_ShowToppic);
        //LoadImageLocal(@"D:\John Watson\Downloads\Telegram Desktop\photo_2022-04-25_19-31-07.jpg", img_ShowToppic);
    }
    private void OnClickLoadUrl(object sender, EventArgs e)
    {
        //SemanticScreenReader.Announce(CounterLabel.Text);
        //LoadImageUrl("http://i2.hdslb.com/bfs/face/9265d2d4e5d7a5c2c04bd635ef959d6e461b0d94.jpg", img_ShowToppic);

    }
    public ICanvas Draw(ICanvas canvas)
    {
        return canvas;
    }
    private void LoadImageLocal(string path, Image img)
    {
        //string curExePath = Environment.ProcessPath;
        //var exeFi = new FileInfo(curExePath);
        //var curPath = exeFi.Directory.FullName;
        //var assetsPath = Path.Combine(curPath, "Assets");
        //var isAssetsPathExists = Directory.Exists(assetsPath);
        //var picturePath = Path.Combine(assetsPath, "xxmchain.jpg");
        var byteArray = File.ReadAllBytes(path);
        img.Source = ImageSource.FromStream(() => new MemoryStream(byteArray));
        //both can use, just for test
        img = new Image
        {
            Source = ImageSource.FromFile(path)
        };
        //var s = File.Exists("BiliAvatarMAUI.Assets.xxmchain.jpg");

    }
    private void LoadImageUrl(string url, Image img)
    {
        var byteArray = new HttpClient().GetByteArrayAsync(url).Result;
        img.Source = ImageSource.FromStream(() => new MemoryStream(byteArray));
    }

    private async void GetLink(object sender, EventArgs e)
    {
        var getLinkButton = sender as Button;
        var linkText = txtLink.Text;
        if (linkText == null || string.IsNullOrWhiteSpace(linkText))
        {
            return;
        }
        else
        {
            var url = DouyinApi.GetUrlFromShareCode(linkText);
            getLinkButton.IsEnabled = false;
            var responseMessage = await WebIO.GetUrl(url);
            var actualUrl = WebIO.ReturnActualUrl(responseMessage);
            var siteType = MediaType.SwitchSiteTypeByLink(actualUrl.AbsoluteUri);
            switch (siteType)
            {
                case MediaType.SourceSiteType.Unknown:
                    break;
                case MediaType.SourceSiteType.Douyin:
                    await DouyinDownload(sender, actualUrl.AbsoluteUri);
                    break;
                case MediaType.SourceSiteType.Bilibli:
                    await BiliDynamicDownload(actualUrl.AbsoluteUri);
                    break;
                case MediaType.SourceSiteType.Twitter:
                    break;
                case MediaType.SourceSiteType.TikTok:
                    break;
                default:
                    break;
            }
            getLinkButton.IsEnabled = true;

        }
    }

    //[ICommand]
    private async void SetDownloadPath(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine($"Pixel width: {DeviceDisplay.Current.MainDisplayInfo.Width} / Pixel Height: {DeviceDisplay.Current.MainDisplayInfo.Height}");
        sb.AppendLine($"Density: {DeviceDisplay.Current.MainDisplayInfo.Density}");
        sb.AppendLine($"Orientation: {DeviceDisplay.Current.MainDisplayInfo.Orientation}");
        sb.AppendLine($"Rotation: {DeviceDisplay.Current.MainDisplayInfo.Rotation}");
        sb.AppendLine($"Refresh Rate: {DeviceDisplay.Current.MainDisplayInfo.RefreshRate}");

        DisplayDetailsLabel.Text = sb.ToString();

        //DeviceOrientationService deviceOrientationService = new DeviceOrientationService();
        //DeviceOrientation orientation = deviceOrientationService.GetOrientation();
        DeviceOrientationService.SetOrientation(DeviceOrientation.Portrait);


        //DeviceDisplay.MainDisplayInfo.Orientation = DisplayOrientation.Portrait;
        FileIO fs = new FileIO();
        string path = await fs.TakePath();
        CounterLabel.Text = path;
        if (!string.IsNullOrEmpty(path))
        {
            FileInfo fi = new FileInfo(path);
            var realPath = fi.Directory;
            savingPath = path;
        }
    }
    //private async Task<bool> DownloadContent(ContentType type,string filepath)
    //{
    //    bool result = await douyin.DownloadVideo(video1080p != string.Empty ? video1080p : videoUrl, filepath);
    //}

    private async Task<string> CopyClipBoard()
    {
        string clipboardText = await Clipboard.Default.GetTextAsync();
        return clipboardText;
    }


    private async void PasteClipBorad(object sender, EventArgs e)
    {
        txtLink.Text = await CopyClipBoard();
    }
    private async Task DouyinDownload(object sender, string Douyinsharelink)
    {
        var getLinkButton = sender as Button;
        //var linkText =Douyinsharelink;
        var videoInfo = new DouyinVideoModel();
        try
        {
            videoInfo = await douyin.GetVideoInfoByApi(Douyinsharelink, txtApiFeild.Text);
        }
        catch (Exception ex)
        {
            DisplayDetailsLabel.Text = ex.Message;
            txtLink.Text = string.Empty;
            getLinkButton.IsEnabled = true;
            return;
        }
        int? awemeType = videoInfo.data.aweme_detail.aweme_type;

        #region Construct video file name
        string video1080p = string.Empty;
        string videoUrl = string.Empty;
        string authorName = string.Empty;
        string authorUid = string.Empty;
        string videoTitle = string.Empty;
        string videoUid = string.Empty;
        List<images> imagesArray = new List<images>();

        video1080p = videoInfo.data.aweme_detail.video.play_addr.url_list[0];
        //video1080p = video1080p.Replace("playwm", "play");
        //video1080p = video1080p.Replace("720p", "1080p");

        //videoUrl = videoInfo.aweme_detail.video.play_addr.url_list[0].Replace("playwm", "play");
        string video720p = videoInfo.data.aweme_detail.video.bit_rate[0].play_addr.url_list.Last();
        string videodefualt = videoInfo.data.aweme_detail.video.play_addr.url_list[0];
        if (!string.IsNullOrEmpty(video720p))
        {
            videoUrl = video720p;
        }
        else
        {
            videoUrl = videodefualt;
        }

        authorUid = videoInfo.data.aweme_detail.author_user_id.ToString();

        authorName = videoInfo.data.aweme_detail.author.nickname;

        videoTitle = videoInfo.data.aweme_detail.desc;

        videoUid = videoInfo.data.aweme_detail.aweme_id.ToString();



        #endregion
        //如果返回Json对象为空则跳出
        if (videoInfo == null)
        {
            CounterLabel.Text = "链接获取失败，请检查分享链接";
            getLinkButton.IsEnabled = true;
            return;
        }

        var MyPictures = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
        DirectoryInfo downloadFullPath = MyPictures;
        if (MyPictures.Exists)
        {

        }
        if (IsAndroid())
        {
            PermissionStatus statusread = await Permissions.RequestAsync<Permissions.StorageRead>();
            PermissionStatus statuswrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
            var Movies = FileSystem.Current.AppDataDirectory;
            savingPath = @"/storage/emulated/0/Pictures";
            if (!Directory.Exists(savingPath))
            {
                //var folderSave = Directory.CreateDirectory(Path.Combine(savingPath, "save"));
                //var files = Directory.EnumerateFiles(savingPath);
                //foreach (var brokeVideo in files)
                //{
                //    //File.Copy(brokeVideo,)
                //}
                savingPath = Movies;
            }
            else
            {
                var newsavingPath = Path.Combine(savingPath, "douyindownload");
                if (Directory.Exists(newsavingPath))
                {
                    savingPath = newsavingPath;
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(newsavingPath);
                        savingPath = newsavingPath;
                    }
                    catch
                    {

                    }
                }
            }
            FileIO fs = new FileIO();
            if (!fs.CheckPathIsCanBeSavedByOpenOrCreateFile(savingPath).Result)
            {
                savingPath = FileSystem.Current.AppDataDirectory;
            }
        }
        if (IsWindows())
        {
            savingPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            savingPath = Path.Combine(savingPath, "DouyinDownload");
            if (!Directory.Exists(savingPath))
            {
                Directory.CreateDirectory(savingPath);
            }

        }
        authorName = Verify.FilterillegalCharacters(authorName);
        videoTitle = Verify.FilterillegalCharacters(videoTitle);

        string filepath = string.Empty;
        switch (awemeType)
        {
            //图集
            //case 2:
            //    imagesArray = videoInfo.aweme_detail.images.Reverse().ToList();
            //    var imageUrls = imagesArray.Select(x => x.url_list.First());
            //    int picIndex = 1;
            //    foreach (var url in imageUrls)
            //    {
            //        filepath = Path.Combine(savingPath, authorUid + "-" + authorName + "-" + videoUid + "-" + picIndex.ToString() + ".png");
            //        if (!File.Exists(filepath))
            //        {
            //            bool result = await douyin.DownloadContent(url, filepath);

            //        }
            //        else
            //        {
            //            CounterLabel.Text = "该图片下载已完成";
            //            txtLink.Text = "";
            //        }
            //        picIndex++;
            //    }
            //    CounterLabel.Text = "下载成功：" + filepath;
            //    txtLink.Text = "";
            //    break;
            //视频
            case 0:
                filepath = Path.Combine(savingPath, authorUid + "-" + authorName + "-" + videoUid + ".mp4");
                //filepath = Verify.FilterillegalCharacters(filepath);

                //FileIO.WriteBinaryToFile(filepath, resp);
                //filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "test.mp4");
                if (!File.Exists(filepath))
                {
                    bool result = await douyin.DownloadContent(video720p != string.Empty ? video720p : videodefualt, filepath);
                    if (result)
                    {
                        CounterLabel.Text = "下载成功：" + filepath;
                        txtLink.Text = "";
                    }
                    else
                    {
                        CounterLabel.Text = "下载失败，请检查链接";
                    }
                }
                else
                {
                    CounterLabel.Text = "该视频下载已完成";
                    txtLink.Text = "";
                }
                break;
            default:
                break;
        }
    }
    private async Task BiliDynamicDownload(string uri)
    {
        Uri biliUri = new Uri(uri);
        var biliPath = biliUri.AbsolutePath;
        var dynamicUUID = biliPath.Split('/').Last();
        var dynamicDtUriBd = new UriBuilder(apiUri);
        dynamicDtUriBd.Path = "bili";
        dynamicDtUriBd.Query = $"dynamicId={dynamicUUID}";
        //var dynamicDtUri = dynamicDtUriBd.Uri;
        //var dynamicDetail = string.Concat(BilibiliApi.BiliQueryApi.Dynamic_detail, dynamicUUID);
        var dynamicresp = await WebIO.Client.GetStringAsync(dynamicDtUriBd.Uri.OriginalString);
        //var baseAddress = new Uri(BilibiliApi.BiliQueryApi.Dynamic_detail);
        //using (var handler = new HttpClientHandler { UseCookies = true })
        //using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
        //{
        //    var message = new HttpRequestMessage(HttpMethod.Get, dynamicUUID);
        //    message.Headers.Add("Cookie", "51296503,1721507837,abf7b*11CjABnrEpyqRX-H8z5eFGOMBIkvyR98tkvnHA3T9MJkA-dXWJzAOq8dBF2on15n9peHASVmstOHk5U2hRYV92QWp0WjJWbDh4VmxvMjRBbUNRSS1CUS1wVVM5WWsxRnRBY3B2dHFsM0YyRlRDcFZUdTQ2aUgwYVF1NzRpUms3MFdMcW1yY25OVVBBIIEC");
        //    var result = await client.GetStringAsync(dynamicDetail);
            //result.EnsureSuccessStatusCode();
            //var con = result.Content;
            //var c = client.
            //var getress = await client.GetAsync(dynamicDetail,)
        //}
        BilibiliApi.DynamicCard.DynamicExtendCard dynmaicCardInfo = null;
        BilibiliApi.Dynamic.Dynamic_Detail_Model dynamicdetailInfo = null;
        BilibiliApi.dynamicMainInfo  dynamicMainInfo = null;
        try
        {

            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.WriteAsString
            };


             dynamicMainInfo = JsonSerializer.Deserialize<BilibiliApi.dynamicMainInfo>(dynamicresp, options);
            //dynamicdetailInfo = JsonSerializer.Deserialize<BilibiliApi.Dynamic.Dynamic_Detail_Model>(dynamicresp, options);
            //var dynamicCardJsonStr = dynamicdetailInfo?.data?.card?.card;
            //dynmaicCardInfo = JsonSerializer.Deserialize<BilibiliApi.DynamicCard.DynamicExtendCard>(dynamicCardJsonStr, options);
        }
        catch (Exception jsonEx)
        {
            return;
        }
        IEnumerable<string> pictureList = null;
        if(dynamicMainInfo.picUris!=null)
        {
            pictureList = dynamicMainInfo.picUris;
        }
        var savingPath = string.Empty;
        var authorUid = dynamicMainInfo.authorId;
        var authorName = dynamicMainInfo.authorName;
        authorName = Verify.FilterillegalCharacters(authorName);
        var videoUid = dynamicUUID;
        var MyPictures = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
        DirectoryInfo downloadFullPath = MyPictures;
        if (MyPictures.Exists)
        {

        }
        if (IsAndroid())
        {
            PermissionStatus statusread = await Permissions.RequestAsync<Permissions.StorageRead>();
            PermissionStatus statuswrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
            var Movies = FileSystem.Current.AppDataDirectory;
            savingPath = @"/storage/emulated/0/Pictures";
            if (!Directory.Exists(savingPath))
            {
                //var folderSave = Directory.CreateDirectory(Path.Combine(savingPath, "save"));
                //var files = Directory.EnumerateFiles(savingPath);
                //foreach (var brokeVideo in files)
                //{
                //    //File.Copy(brokeVideo,)
                //}
                savingPath = Movies;
            }
            else
            {
                var newsavingPath = Path.Combine(savingPath, "biliDownload");
                if (Directory.Exists(newsavingPath))
                {
                    savingPath = newsavingPath;
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(newsavingPath);
                        savingPath = newsavingPath;
                    }
                    catch
                    {

                    }
                }
            }
            FileIO fs = new FileIO();
            if (!fs.CheckPathIsCanBeSavedByOpenOrCreateFile(savingPath).Result)
            {
                savingPath = FileSystem.Current.AppDataDirectory;
            }
        }
        if (IsWindows())
        {
            savingPath = MyPictures.FullName;
            savingPath = Path.Combine(savingPath, "biliDownload");
            if (!Directory.Exists(savingPath))
            {
                Directory.CreateDirectory(savingPath);
            }

        }
        var picIndex = 1;
        var filepath = string.Empty;
        if (pictureList == null)
        {
            return;
        }
        foreach (var url in pictureList)
        {
            filepath = Path.Combine(savingPath, authorUid + "-" + authorName + "-" + videoUid + "-" + picIndex.ToString() + ".png");
            if (!File.Exists(filepath))
            {
                bool result = await douyin.DownloadContent(url, filepath);

            }
            else
            {
                CounterLabel.Text = "该图片下载已完成";
                txtLink.Text = "";
            }
            picIndex++;
        }
        picIndex = 1;
        CounterLabel.Text = "下载成功：" + filepath;
        txtLink.Text = "";
    }

    private async void btn_SaveApi_Clicked(object sender, EventArgs e)
    {

    }
    private async void GetConfigApi()
    {
        var savingPath = string.Empty;
        if (IsWindows())
        {
            savingPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            savingPath = Path.Combine(savingPath, "DouyinDownload");
            if (!Directory.Exists(savingPath))
            {
                Directory.CreateDirectory(savingPath);
            }

        }
        if (IsAndroid())
        {
            PermissionStatus statusread = await Permissions.RequestAsync<Permissions.StorageRead>();
            PermissionStatus statuswrite = await Permissions.RequestAsync<Permissions.StorageWrite>();
            var Movies = FileSystem.Current.AppDataDirectory;
            savingPath = @"/storage/emulated/0/Pictures";
        }
        var apiFileName = "ApiConfig.toml";
        var apiFullFilePath = Path.Combine(savingPath, apiFileName);
        if (!File.Exists(apiFullFilePath))
        {
            await File.WriteAllTextAsync(apiFullFilePath, "");
        }
        var apiConfigText = await File.ReadAllTextAsync(apiFullFilePath);
        if (!string.IsNullOrEmpty(apiConfigText))
        {

            try
            {
                var configModel = Toml.ToModel(apiConfigText);
                apiUri = configModel["apiUri"].ToString();
            }
            catch
            {
                DisplayDetailsLabel.Text = "请在/storage/emulated/0/Pictures.ApiConfig.toml 中输入api地址并保存！";
            }
            if (!string.IsNullOrEmpty(apiUri))
            {
                txtApiFeild.Text = apiUri;
            }
        }
    }
}

