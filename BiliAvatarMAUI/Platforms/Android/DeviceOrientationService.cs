using Android.Content;
using Android.Runtime;
using Android.Views;
using BiliAvatarMAUI.Services;

namespace BiliAvatarMAUI.Services.PartialMethods;

//public partial class DeviceOrientationService
//{
//    //    public  partial DeviceOrientation GetOrientation()
//    //    {
//    //        IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
//    //        SurfaceOrientation orientation = windowManager.DefaultDisplay.Rotation;
//    //        bool isLandscape = orientation == SurfaceOrientation.Rotation90 || orientation == SurfaceOrientation.Rotation270;
//    //        return isLandscape ? DeviceOrientation.Landscape : DeviceOrientation.Portrait;
//    //    }
//}
public static partial class DeviceOrientationService

{

    private static MauiAppCompatActivity _activity;

    public static partial void Init(object activity)

    {

        _activity = (MauiAppCompatActivity)activity;

    }

    public static partial DeviceOrientation GetOrientation()

    {

        IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

        SurfaceOrientation orientation = windowManager.DefaultDisplay.Rotation;

        bool isLandscape = orientation == SurfaceOrientation.Rotation90 || orientation == SurfaceOrientation.Rotation270;

        return isLandscape ? DeviceOrientation.Landscape : DeviceOrientation.Portrait;

    }

    public static partial void SetOrientation(DeviceOrientation orientation)

    {

        switch (orientation)

        {

            case DeviceOrientation.Landscape:

                _activity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;

                break;

            case DeviceOrientation.Undefined:

            case DeviceOrientation.Portrait:

            default:

                _activity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;

                break;

        }

    }

}
