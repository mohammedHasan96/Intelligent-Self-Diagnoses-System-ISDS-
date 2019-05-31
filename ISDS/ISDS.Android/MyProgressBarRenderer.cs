using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ISDS.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ProgressBar), typeof(MyProgressBarRenderer))]
namespace ISDS.Droid
{
    public class MyProgressBarRenderer : ProgressBarRenderer
    {

        public MyProgressBarRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            Control.ProgressDrawable.SetColorFilter(Android.Graphics.Color.Argb(255, 182, 231, 233), Android.Graphics.PorterDuff.Mode.SrcIn);
            Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Argb(255, 182, 231, 233));
            Control.ScaleY = 20; // This changes the height

        }
    }
}