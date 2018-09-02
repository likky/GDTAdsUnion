using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.QQ.E.Ads.Interstitial;
using Com.QQ.E.Comm.Util;

namespace GDTAdsUnion
{
    public class InterstitialListener : AbstractInterstitialADListener
    {
        public override void OnADReceive()
        {
            InterstitialADActivity.interstitialAD.Show();

        }

        public override void OnNoAD(AdError p0)
        {
          
        }
    }
}