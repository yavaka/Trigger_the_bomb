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
using Xamarin.Forms;
using Android.Gms.Ads;
using Xamarin.Forms.Platform.Android;
using TriggerTheBomb.Droid;

[assembly: ExportRenderer(typeof(TriggerTheBomb.AdControlView), typeof(AdViewRenderer))]
namespace TriggerTheBomb.Droid
{
    public class AdViewRenderer : 
        ViewRenderer<TriggerTheBomb.AdControlView, AdView>
    {
        string adUnitAd = "ca-app-pub-3877751906354570/1042548730";
        AdSize adSize = AdSize.SmartBanner;
        AdView adView;

        AdView CreateAdView()
        {
            if (adView != null)
            {
                return adView;
            }

            adView = new AdView(Forms.Context);
            adView.AdSize = adSize;
            adView.AdUnitId = adUnitAd;

            var adParams = new LinearLayout.LayoutParams(
                LayoutParams.WrapContent, LayoutParams.WrapContent);
            adView.LayoutParameters = adParams;

            adView.LoadAd(new AdRequest.Builder().Build());
            return adView;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                CreateAdView();
                SetNativeControl(adView);
            }
        }
    }
}