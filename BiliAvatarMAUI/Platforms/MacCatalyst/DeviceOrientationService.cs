using BiliAvatarMAUI.Services;

namespace BiliAvatarMAUI.Services.PartialMethods;

public partial class DeviceOrientationService
{
    public static partial DeviceOrientation GetOrientation()
    {
        //UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;
        //bool isPortrait = orientation == UIInterfaceOrientation.Portrait || orientation == UIInterfaceOrientation.PortraitUpsideDown;
        return DeviceOrientation.Portrait;
    }
    public static partial void SetOrientation(DeviceOrientation orientation)
    {

    }
    public static partial void Init(object activity)
    {

    }
}