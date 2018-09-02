using Android.App;
using Android.Widget;
using Android.OS;
using Com.QQ.E.Ads.Banner;
using Com.QQ.E.Comm.Util;
using Android.Text.Util;
using Android.Views;
using Android.Util;
using Java.Lang;
using Android.Webkit;
using System.Collections.Generic;
using Android;
using Android.Support.V4.App;
using Android.Content.PM;
using Android.Content;

namespace GDTAdsUnion
{
    [Activity(Label = "GDTAdsUnion", MainLauncher = true,WindowSoftInputMode = SoftInput.StateHidden|SoftInput.StateAlwaysHidden)]
    public class BannerActivity : Activity
    {
        private ViewGroup bannerContainer;
        private BannerView bannerView;
        public static readonly string APPID = "1101152570";
        public static readonly string BannerPosID = "9079537218417626401";
        int PERMISSION_REQUESTCODE = 1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.banner);
            //动态申请权限
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
            {
                Permission();
            }
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {
                WebView.SetWebContentsDebuggingEnabled(true);
            }
                bannerContainer = this.FindViewById<FrameLayout>(Resource.Id.bannerContainer);
            FindViewById<EditText>(Resource.Id.posId).Text = BannerPosID;
            var button1= FindViewById(Resource.Id.refreshBanner) as Button;
            var button2 = FindViewById(Resource.Id.closeBanner) as Button;
            var button3 = FindViewById(Resource.Id.interstitial) as Button;
            this.bannerView = new BannerView(this, ADSize.Banner, APPID, BannerPosID);
            // 注意：如果开发者的banner不是始终展示在屏幕中的话，请关闭自动刷新，否则将导致曝光率过低。
            // 并且应该自行处理：当banner广告区域出现在屏幕后，再手动loadAD。
            bannerView.SetRefresh(30);
            bannerView.SetADListener(new BannerListener());
            bannerContainer.AddView(bannerView);
            bannerView.LoadAD();

            button1.Click += delegate
            {
                GetBanner().LoadAD();
            };

            button2.Click += delegate
            {
                bannerContainer.RemoveAllViews();
                if (bannerView!=null)
                {
                    bannerView.Destroy();
                    bannerView = null;
                }
            };

            button3.Click += delegate
            {
                Intent intent = new Intent(this, typeof(InterstitialADActivity));
                StartActivity(intent);
            };

        }

        private BannerView GetBanner()
        {
            //if (this.bannerView != null)
            //{
            //    bannerContainer.RemoveView(bannerView);
            //    bannerView.Destroy();
            //}
            this.bannerView = new BannerView(this, ADSize.Banner, APPID, BannerPosID);

            // 注意：如果开发者的banner不是始终展示在屏幕中的话，请关闭自动刷新，否则将导致曝光率过低。
            // 并且应该自行处理：当banner广告区域出现在屏幕后，再手动loadAD。
            bannerView.SetRefresh(30);
            bannerView.SetADListener(new BannerListener());
            bannerContainer.AddView(bannerView);
            return bannerView;

        }

        public void Permission()
        {
            List<string> permissionList = new List<string>();
            bool isGrant1 = ActivityCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted;
            if (isGrant1 == false)
            {
                permissionList.Add(Manifest.Permission.WriteExternalStorage);
            }

            bool isGrant2 = ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) == Android.Content.PM.Permission.Granted;
            if (isGrant2 == false)
            {
                permissionList.Add(Manifest.Permission.AccessFineLocation);
            }
            bool isGrant3 = ActivityCompat.CheckSelfPermission(this, Manifest.Permission.ReadPhoneState) == Android.Content.PM.Permission.Granted;
            if (isGrant3 == false)
            {
                permissionList.Add(Manifest.Permission.ReadPhoneState);
            }

            if (permissionList.Count != 0)
            {
                string[] str = permissionList.ToArray();
                ActivityCompat.RequestPermissions(this, str, PERMISSION_REQUESTCODE);
            }
            else
            {
                Toast.MakeText(this, "权限都授权了！", ToastLength.Short).Show();
            }


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == PERMISSION_REQUESTCODE)
            {
                int k = 0;
                if (grantResults.Length > 0)
                {
                    for (int i = 0; i < grantResults.Length; i++)
                    {
                        if (grantResults[i] != Android.Content.PM.Permission.Granted)
                        {
                            k++;
                            Toast.MakeText(this, "有权限未授予，广告无法显示！", ToastLength.Short).Show();
                        }

                    }
                    if (k == 0)
                    {
                        //InitialDat();
                    }

                }
            }

        }

    }
}

