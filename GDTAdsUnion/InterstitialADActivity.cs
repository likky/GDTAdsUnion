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
    [Activity(Label = "GDTAdsUnion")]
    public class InterstitialADActivity : Activity
    {
        public static InterstitialAD interstitialAD;
        string InterteristalPosID= "8575134060152130849";
        string APPID = "1101152570";
        bool isButton1;


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
                GetAD().SetADListener(new InterstitialListener());
                interstitialAD.LoadAD();
            };

            button2.Click += delegate
            {
                isButton1 = false;
                GetAD().SetADListener(new InterstitialListener());
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