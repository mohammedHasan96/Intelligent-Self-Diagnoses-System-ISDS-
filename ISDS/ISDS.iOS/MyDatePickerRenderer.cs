using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using ISDS.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DatePicker), typeof(MyDatePickerRenderer))]
namespace ISDS.iOS
{
    class MyDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.BackgroundColor = UIColor.FromRGBA(0, 0, 0, 0);
            }
        }
    }
}