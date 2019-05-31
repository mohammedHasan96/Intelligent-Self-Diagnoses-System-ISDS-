using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using ISDS.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ProgressBar), typeof(MyProgressBarRenderer))]
namespace ISDS.iOS
{
    public class MyProgressBarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(
         ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            Control.ProgressTintColor = Color.FromRgb(182, 231, 233).ToUIColor();// If you want to change the color

        }


        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var X = 1.0f;
            var Y = 20.0f; //This changes the height

            CGAffineTransform transform = CGAffineTransform.MakeScale(X, Y);
            this.Transform = transform;
        }
    }
}