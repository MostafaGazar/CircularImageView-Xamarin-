using System;
using Android.Content;
using Android.Util;
using Android.Graphics;
using Android.Widget;

namespace CircularImageView.Library
{
	public class CircularImageView : BaseImageView
	{
		public CircularImageView (Context context) :
			base (context)
		{
		}

		public CircularImageView (Context context, IAttributeSet attrs) :
			base (context, attrs)
		{
		}

		public CircularImageView (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
		}

		public override Bitmap GetBitmap ()
		{
			Bitmap maskBitmap = Bitmap.CreateBitmap (Width, Height, Bitmap.Config.Argb4444);
			Canvas canvas = new Canvas (maskBitmap);

			int radius = Math.Min (Width, Height) / 2;
			canvas.DrawCircle (radius, radius, radius, mPaint);

			return maskBitmap;
		}

	}
}