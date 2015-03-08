using System;
using Android.Content;

namespace CircularImageView.Android
{
	/// <summary>
	/// Class containing some UI related utility methods.
	/// </summary>
	public class UiUtils
	{

		public static float ConvertDpToPx (Context context, int sizeInDp)
		{
			float density = context.Resources.DisplayMetrics.Density;

			return sizeInDp * density;
		}

		public static float ConvertPxToDp (Context context, int sizeInPx)
		{
			float density = context.Resources.DisplayMetrics.Density;

			return sizeInPx / density;
		}

	}
}

