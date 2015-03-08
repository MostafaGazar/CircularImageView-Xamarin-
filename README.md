CircularImageView
=======

Circular ImageView and Drawable, Xamarin Android library, and samples project.

Usage
-----
        Bitmap bitmap = BitmapFactory.DecodeResource (Resources, Resource.Drawable.sample);
		CircularDrawable d = new CircularDrawable (bitmap, 
			                     (int)UiUtils.ConvertDpToPx (ApplicationContext, margin), 
			                     UiUtils.ConvertDpToPx (ApplicationContext, strokeWidth),
			                     Color.White);
		drawableImageView.SetBackgroundDrawable (d);


Screenshots
------------
![main](https://raw.github.com/MostafaGazar/CircularImageView-Xamarin-/master/screens/1.png)

Developed by
------------
* Mostafa Gazar - <eng.mostafa.gazar@gmail.com>

