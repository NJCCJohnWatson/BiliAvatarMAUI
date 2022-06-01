//using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;
using Microsoft.Maui.Graphics;
using System.Drawing;
using BiliAvatarMAUI.Douyin;

namespace BiliAvatarMAUI;

public partial class MainPage : ContentPage
{
    int count = 0;
    DouyinApi douyin = new DouyinApi();
    bool IsAndroid() =>
    DeviceInfo.Current.Platform == DevicePlatform.Android;
    bool IsWindows() =>
        DeviceInfo.Current.Platform == DevicePlatform.WinUI;
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
        string curExePath = Environment.ProcessPath;
        var exeFi = new FileInfo(curExePath);
        var curPath = exeFi.Directory.FullName;
        var assetsPath = Path.Combine(curPath, "Assets");
        var isAssetsPathExists = Directory.Exists(assetsPath);
        //var picturePath = Path.Combine(assetsPath, "xxmchain.jpg");
        //var byteArray = File.ReadAllBytes(picturePath);
        //img.Source = ImageSource.FromStream(() => new MemoryStream(byteArray));
        //img = new Image
        //{
        //    Source = ImageSource.FromFile("dage.jpg")
        //};
        //var s = File.Exists("BiliAvatarMAUI.Assets.xxmchain.jpg");

    }
    private void LoadImageUrl(string url, Image img)
    {
        var byteArray = new HttpClient().GetByteArrayAsync(url).Result;
        img.Source = ImageSource.FromStream(() => new MemoryStream(byteArray));
    }

    private async void GetLink(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtServerAdress.Text))
        {
            CounterLabel.Text = "服务器IP未设置！";
            return;
        }

        var linkText = txtLink.Text;
        if (linkText == null || string.IsNullOrWhiteSpace(linkText))
        {

        }
        else
        {
            string serrverIP = txtServerAdress.Text;
            string apiUrl = ("http://" + serrverIP + "/api?url=\"" + linkText + "\"");
            var videoInfo = await douyin.GetVideoInfoByApi(apiUrl);
            #region Construct video file name
            string video1080p = string.Empty;
            string videoUrl = string.Empty;
            string authorName = string.Empty;
            string authorUid = string.Empty;
            string videoTitle = string.Empty;
            foreach (var item in videoInfo)
            {
                if (item.Key.Contains("nwm_video_url_1080p"))
                {
                    video1080p = item.Value;
                }
                if (item.Key.Contains("nwm_video_url") && item.Key == "nwm_video_url")
                {
                    videoUrl = item.Value;
                }
                if (item.Key.Contains("video_author_uid"))
                {
                    authorUid = item.Value;
                }
                if (item.Key.Contains("video_author") && item.Key == "video_author")
                {
                    authorName = item.Value;
                }
                if (item.Key.Contains("video_title"))
                {
                    videoTitle = item.Value;
                }
            }
            #endregion
            //string picpath = FileIO.TakePath().Result;
            var MyPictures = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            DirectoryInfo downloadFullPath = MyPictures;
            if (MyPictures.Exists)
            {

            }
            if (IsAndroid())
            {
                var Movies = FileSystem.Current.AppDataDirectory;
                //savingPath = @"/storage/emulated/0/Pictures";
                if (!Directory.Exists(savingPath))
                {
                    savingPath = Movies;
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
            string filepath = Path.Combine(savingPath, authorUid + "-" + authorName + "-" + videoTitle + ".mp4");
            //FileIO.WriteBinaryToFile(filepath, resp);
            //filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "test.mp4");
            bool result = await douyin.DownloadVideo(video1080p != string.Empty ? video1080p : videoUrl, filepath);
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
    }

    private async void SetDownloadPath(object sender, EventArgs e)
    {
        FileSys fs = new FileSys();
        string path = await fs.TakePath();
        CounterLabel.Text = path;
        FileInfo fi = new FileInfo(path);
        var realPath = fi.Directory;
        savingPath = path;
    }
    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        Clipboard.Default.ClipboardContentChanged += Clipboard_ClipboardContentChanged;
    }
    private async void Clipboard_ClipboardContentChanged(object sender, EventArgs e)
    {
        var clipBoardText = await Clipboard.Default.GetTextAsync();
    }

    private  void ContentPage_Focused(object sender, FocusEventArgs e)
    {
        
    }
    private async void Clipboard_ClipboardContainTiktokLink(object sender, EventArgs e)
    {
        var clipBoardText = await Clipboard.Default.GetTextAsync();
    }
}

