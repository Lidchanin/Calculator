using Android.Content;
using Android.Graphics.Drawables;
using Calculator.Controls;
using Calculator.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace Calculator.Droid.Renderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = new ColorDrawable(Color.Transparent);

                //Need to change keyboard visibility
                //https://github.com/xamarin/Xamarin.Forms/issues/4555
                Control.ShowSoftInputOnFocus = false;
            }
        }
    }
}