using BiliAvatarMAUI.Services;
using UIKit;

namespace BiliAvatarMAUI.Services.PartialMethods;

public partial class DeviceOrientationService
{
    public static partial DeviceOrientation GetOrientation()
    {
        UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;
        bool isPortrait = orientation == UIInterfaceOrientation.Portrait || orientation == UIInterfaceOrientation.PortraitUpsideDown;
        return isPortrait ? DeviceOrientation.Portrait : DeviceOrientation.Landscape;
    }
    public static partial void SetOrientation(DeviceOrientation orientation)
    {

    }
    public static partial void Init(object activity)
    {

    }
}