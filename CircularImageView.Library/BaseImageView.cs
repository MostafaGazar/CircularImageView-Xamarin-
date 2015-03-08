
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
using Android.Graphics;
using Android.Graphics.Drawables;

namespace CircularImageView.Library
{
	public abstract class BaseImageView : ImageView
	{

		private Context mContext;

		private static readonly Xfermode sXfermode = new PorterDuffXfermode (PorterDuff.Mode.DstIn);

		protected readonly Paint mPaint;

		public BaseImageView (Context context) :
			this (context, null)
		{
		}

		public BaseImageView (Context context, IAttributeSet attrs) :
			this (context, attrs, -1)
		{
		}

		public BaseImageView (Context context, IAttributeSet attrs, int defStyle) :
			base (context, attrs, defStyle)
		{
			mContext = context;

			mPaint = new Paint (PaintFlags.AntiAlias);
		}

		protected override void OnDraw (Canvas canvas)
		{
			if (!IsInEditMode) {
				int i = canvas.SaveLayer (0.0f, 0.0f, Width, Height, null, SaveFlags.All);

				try {
					Bitmap bitmap = null;

					Drawable drawable = Drawable;
					if (drawable != null) {
						// Allocation onDraw but it's ok because it will not always be called.
						bitmap = Bitmap.CreateBitmap (Width, Height, Bitmap.Config.Argb8888);
						Canvas bitmapCanvas = new Canvas (bitmap);
						drawable.SetBounds (0, 0, Width, Height);
						drawable.Draw (bitmapCanvas);

						Bitmap maskBitmap = GetBitmap ();

						// Draw Bitmap.
						mPaint.Reset ();
						mPaint.FilterBitmap = false;
						mPaint.SetXfermode (sXfermode);

						bitmapCanvas.DrawBitmap (maskBitmap, 0.0f, 0.0f, mPaint);

					}

					// Bitmap already loaded.
					if (bitmap != null) {
						mPaint.SetXfermode (null);
						canvas.DrawBitmap (bitmap, 0.0f, 0.0f, mPaint);

						return;
					}
				} catch (Exception e) {
					// NOTE :: Not necessarily a very good idea to intervene with the garbage collector.
					System.GC.Collect ();

					// Failed to draw.
				} finally {
					canvas.RestoreToCount (i);
				}
			} else {
				base.OnDraw (canvas);
			}
		}

		public abstract Bitmap GetBitmap ();

	}
}

