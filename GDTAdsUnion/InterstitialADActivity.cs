using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.QQ.E.Ads.Interstitial;
using Com.QQ.E.Comm.Util;

namespace GDTAdsUnion
{
    [Activity(Label = "GDTAdsUnion", MainLauncher = true)]
    public class InterstitialADActivity : Activity,IInterstitialADListener
    {
        InterstitialAD interstitialAD;
        string posId;
        string InterteristalPosID= "8575134060152130849";
        string APPID = "1101152570";
        bool isButton1;

        public void OnADClicked()
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

        public void OnADOpened()
        {
          
        }

        public void OnADReceive()
        {
            Log.Info("AD_DEMO", "ONBannerReceive");
            if (isButton1 == true)
            {
                interstitialAD.Show();
            }
            else
            {
                interstitialAD.ShowAsPopupWindow();
            }

        }

        public void OnNoAD(AdError p0)
        {
        
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.interstitial_ads);
            FindViewById<EditText>(Resource.Id.posId).Text = InterteristalPosID;
            var button1 = FindViewById(Resource.Id.showIAD) as Button;
            var button2 = FindViewById(Resource.Id.showIADAsPPW) as Button;
            var button3 = FindViewById(Resource.Id.closePPWIAD) as Button;

            button1.Click += delegate
            {
                isButton1 = true;
                GetAD().SetADListener(this);
                interstitialAD.LoadAD();
            };

            button2.Click += delegate
            {
                isButton1 = false;
                GetAD().SetADListener(this);
                interstitialAD.LoadAD();
            };

            button3.Click += delegate
            {
                if (interstitialAD != null)
                {
                    interstitialAD.ClosePopupWindow();
                }
            };

        }

        private InterstitialAD GetAD()
        {
            if (interstitialAD==null)
            {
                interstitialAD = new InterstitialAD(this, APPID, InterteristalPosID);
            }

            return interstitialAD;
        }


    }
}