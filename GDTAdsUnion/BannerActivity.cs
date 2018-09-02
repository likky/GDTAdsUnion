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

namespace GDTAdsUnion
{
    [Activity(Label = "GDTAdsUnion", WindowSoftInputMode = SoftInput.StateHidden|SoftInput.StateAlwaysHidden)]
    public class BannerActivity : Activity,IBannerADListener
    {
        //private ViewGroup bannerContainer;
        FrameLayout bannerContainer;
        private BannerView bannerView;
        private string posId;
        public static readonly string APPID = "1101152570";
        public static readonly string BannerPosID = "9079537218417626401";

        //public static readonly string APPID = "1107739639";
        //public static readonly string BannerPosID = "7030437914512422";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.banner);
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {
                WebView.SetWebContentsDebuggingEnabled(true);
            }
                bannerContainer = this.FindViewById<FrameLayout>(Resource.Id.bannerContainer);
            FindViewById<EditText>(Resource.Id.posId).Text = BannerPosID;
            var button1= FindViewById(Resource.Id.refreshBanner) as Button;
            var button2 = FindViewById(Resource.Id.closeBanner) as Button;
            this.bannerView = new BannerView(this, ADSize.Banner, APPID, BannerPosID);
            // 注意：如果开发者的banner不是始终展示在屏幕中的话，请关闭自动刷新，否则将导致曝光率过低。
            // 并且应该自行处理：当banner广告区域出现在屏幕后，再手动loadAD。
            bannerView.SetRefresh(30);
            bannerView.SetADListener(this);
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

        }

        private BannerView GetBanner()
        {
            //string posId2 = FindViewById<EditText>(Resource.Id.posId).Text;
            //if (this.bannerView != null && posId2.Equals(BannerPosID))
            //{
            //    return this.bannerView;
            //}
            //if (this.bannerView != null)
            //{
            //    bannerContainer.RemoveView(bannerView);
            //    bannerView.Destroy();
            //}
            //this.posId = posId2;
            this.bannerView = new BannerView(this, ADSize.Banner, APPID, BannerPosID);

            // 注意：如果开发者的banner不是始终展示在屏幕中的话，请关闭自动刷新，否则将导致曝光率过低。
            // 并且应该自行处理：当banner广告区域出现在屏幕后，再手动loadAD。
            bannerView.SetRefresh(30);
            bannerView.SetADListener(this);
            bannerContainer.AddView(bannerView);
            return bannerView;

        }

        public void OnADClicked()
        {

        }

        public void OnADCloseOverlay()
        {

        }

        public void OnADClosed()
        {
   
        }

        public void OnADExposure()
        {
     
        }

        public void OnADLeftApplication()
        {
  
        }

        public void OnADOpenOverlay()
        {
     
        }

        public void OnADReceiv()
        {
            Log.Info("AD_DEMO", "ONBannerReceive");
            Toast.MakeText(this, "收到广告", ToastLength.Short).Show();
        }

        public void OnNoAD(AdError p0)
        {
            Toast.MakeText(this, "没有广告", ToastLength.Short).Show();
        }
    }
}

