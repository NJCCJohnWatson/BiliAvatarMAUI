//using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;
using Microsoft.Maui.Graphics;
using System.Drawing;
using BiliAvatarMAUI.Douyin;
using InvokePlatformCodeDemos.Services;
using BiliAvatarMAUI.Services.PartialMethods;
using BiliAvatarMAUI.Services;

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

    public MainPage()
    {
        InitializeComponent();

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

        }
        else
        {
            getLinkButton.IsEnabled = false;
            var videoInfo = new WebApiV2ByID();
            try
            {
                videoInfo = await douyin.GetVideoInfoByApi(linkText);
            }
            catch (Exception ex) 
            {
                DisplayDetailsLabel.Text = ex.Message;
                return;
            }
            int? awemeType = videoInfo.item_list.FirstOrDefault().aweme_type;

            #region Construct video file name
            string video1080p = string.Empty;
            string videoUrl = string.Empty;
            string authorName = string.Empty;
            string authorUid = string.Empty;
            string videoTitle = string.Empty;
            string videoUid = string.Empty;
            List<images> imagesArray = new List<images>();

            video1080p = videoInfo.item_list[0].video.play_addr.url_list[0];
            video1080p = video1080p.Replace("playwm", "play");
            video1080p = video1080p.Replace("720p", "1080p");

            videoUrl = videoInfo.item_list[0].video.play_addr.url_list[0].Replace("playwm", "play");

            authorUid = videoInfo.item_list[0].author_user_id.ToString();

            authorName = videoInfo.item_list[0].author.nickname;

            videoTitle = videoInfo.item_list[0].desc;

            videoUid = videoInfo.item_list[0].aweme_id.ToString();



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
                if(!fs.CheckPathIsCanBeSavedByOpenOrCreateFile(savingPath).Result)
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
                case 2:
                    imagesArray = videoInfo.item_list[0].images.Reverse().ToList();
                    var imageUrls = imagesArray.Select(x => x.url_list.First());
                    int picIndex = 1;
                    foreach (var url in imageUrls)
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
                    CounterLabel.Text = "下载成功：" + filepath;
                    txtLink.Text = "";
                    break;
                //视频
                case 4:
                    filepath = Path.Combine(savingPath, authorUid + "-" + authorName + "-" + videoUid + ".mp4");
                    //filepath = Verify.FilterillegalCharacters(filepath);

                    //FileIO.WriteBinaryToFile(filepath, resp);
                    //filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "test.mp4");
                    if (!File.Exists(filepath))
                    {
                        bool result = await douyin.DownloadContent(video1080p != string.Empty ? video1080p : videoUrl, filepath);
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

}

