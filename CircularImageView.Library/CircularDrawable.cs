using System;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace CircularImageView.Library
{
	/// <summary>
	/// Cropping Drawable using circular shape and draw and outer circular stroke.
	/// </summary>
	public class CircularDrawable : Drawable
	{

		private readonly Bitmap mBitmap;
		private readonly RectF mRect = new RectF ();
		private readonly Paint mPaint;
		private readonly Paint mStrokePaint;
		private BitmapShader mBitmapShader;

		private readonly int mMargin;
		private readonly float mStrokeWidth;

		public CircularDrawable (Bitmap bitmap)
			: this (bitmap, 0, 0, Color.Transparent)
		{

		}

		public CircularDrawable (Bitmap bitmap, int margin, float strokeWidth, Color strokeColor)
		{
			mBitmap = bitmap;

			mPaint = new Paint ();
			mPaint.AntiAlias = true;

			mStrokePaint = new Paint ();
			mStrokePaint.AntiAlias = true;
			mStrokePaint.StrokeWidth = strokeWidth;
			mStrokePaint.Color = strokeColor;
			mStrokePaint.SetStyle (Paint.Style.Stroke);

			mMargin = margin;
			mStrokeWidth = strokeWidth;
		}

		protected override void OnBoundsChange (Rect bounds)
		{
			base.OnBoundsChange (bounds);
			float width = bounds.Width () - mMargin;
			float height = bounds.Height () - mMargin;

			mRect.Set (mMargin, mMargin, width, height);

			Bitmap scaledBitmap = Bitmap.CreateScaledBitmap (mBitmap, bounds.Width (), bounds.Height (), false);
			mBitmapShader = new BitmapShader (scaledBitmap, Shader.TileMode.Clamp, Shader.TileMode.Clamp);

			mPaint.SetShader (mBitmapShader);
		}

		public override void Draw (Canvas canvas)
		{
			canvas.DrawCircle (mRect.CenterX (), mRect.CenterY (), mRect.CenterX (), mPaint);
			canvas.DrawCircle (mRect.CenterX (), mRect.CenterY (), mRect.CenterX () - mStrokeWidth / 2, mStrokePaint);
		}

		public override int Opacity {
			get {
				return (int)Format.Translucent;
			}
		}

		public override void SetAlpha (int alpha)
		{
			mPaint.Alpha = alpha;
		}

		public override void SetColorFilter (ColorFilter cf)
		{
			mPaint.SetColorFilter (cf);
		}
	}
}

