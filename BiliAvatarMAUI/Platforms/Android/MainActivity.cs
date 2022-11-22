﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using BiliAvatarMAUI.Services.PartialMethods;
using System.Runtime.Versioning;

namespace BiliAvatarMAUI;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        //base.OnCreate(savedInstanceState);
        try
        {
            if (!Android.OS.Environment.IsExternalStorageManager)
            {
                Intent intent = new Intent();
                intent.SetAction(Android.Provider.Settings.ActionManageAppAllFilesAccessPermission);
                Android.Net.Uri uri = Android.Net.Uri.FromParts("package", this.PackageName, null);
                intent.SetData(uri);
                StartActivity(intent);
            }
            base.OnCreate(savedInstanceState);
        }
        catch
        {
            base.OnCreate(savedInstanceState);
        }
        DeviceOrientationService.Init(this);
    }
}
