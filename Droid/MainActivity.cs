using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin.Forms.Platform.Android;

namespace LaChonaWeb.Droid
{
	[Activity (Label = "La Chona Web", Theme = "@style/MyTheme",ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			ImageCircleRenderer.Init();
			LoadApplication (new App ());
		}
	}
}

