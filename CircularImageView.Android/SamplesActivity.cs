using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CircularImageView.Library;
using Android.Graphics;
using System.Threading;

namespace CircularImageView.Android
{
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class SamplesActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.activity_samples);


			const int margin = 0; // Dp!
			const int strokeWidth = 4; // Dp!

			ImageView drawableImageView = (ImageView)FindViewById (Resource.Id.drawable_image_view);

			Bitmap bitmap = BitmapFactory.DecodeResource (Resources, Resource.Drawable.sample);
			CircularDrawable d = new CircularDrawable (bitmap, 
				                     (int)UiUtils.ConvertDpToPx (ApplicationContext, margin), 
				                     UiUtils.ConvertDpToPx (ApplicationContext, strokeWidth),
				                     Color.White);
			drawableImageView.SetBackgroundDrawable (d);
		}

	}
}


