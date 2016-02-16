using System;
using LaChonaWeb.Droid;
using LaChonaWeb;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Webkit;
using Android.App;
using Android.Widget;


[assembly : ExportRenderer(typeof(CustomWebView),typeof(AndroidCustomWebView))]
namespace LaChonaWeb.Droid
{
	public class AndroidCustomWebView : ViewRenderer<CustomWebView, global::Android.Views.View>
	{

		static CustomWebView CustomWebView { get; set;}
		static ProgressDialog ActiveIndicator { get; set;} 		
		public AndroidCustomWebView ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<CustomWebView> e)
		{
			base.OnElementChanged (e);
			if (Element != null) {
				CustomWebView = (CustomWebView)Element;
				LinearLayout contentView = new LinearLayout (Forms.Context);

				ActiveIndicator = new ProgressDialog(Forms.Context);
				ActiveIndicator.SetMessage ("Loading Page......");
				ActiveIndicator.SetProgressStyle (ProgressDialogStyle.Spinner);

				var webView = new  Android.Webkit.WebView (Forms.Context);
				webView.Settings.JavaScriptEnabled = true;
				webView.LoadUrl (CustomWebView.Source);
				webView.SetWebViewClient (new Callback());
				contentView.AddView(webView);
				SetNativeControl(contentView);
			}

		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName == "LoadPageFinished") {
				CustomWebView.LoadCompleted (sender, e);
			}
			else if (e.PropertyName == "LoadPageStarted") {
				CustomWebView.LoadStarted (sender, e);
			}
			else if (e.PropertyName == "LoadPageFailed") {
				CustomWebView.LoadFailed (sender, e);
			}
		}

		private class Callback : WebViewClient {
			public override void OnPageFinished (Android.Webkit.WebView view, string url)
			{
				base.OnPageFinished (view, url);
				ActiveIndicator.Hide ();
				CustomWebView.LoadCompleted (this, new EventArgs ());
			}

			public override void OnPageStarted (Android.Webkit.WebView view, string url, Android.Graphics.Bitmap favicon)
			{
				base.OnPageStarted (view, url, favicon);
				ActiveIndicator.Show ();
				CustomWebView.LoadStarted (this, new EventArgs ());
			}

			public override void OnReceivedHttpError (Android.Webkit.WebView view, IWebResourceRequest request, WebResourceResponse errorResponse)
			{
				base.OnReceivedHttpError (view, request, errorResponse);
				CustomWebView.LoadFailed (this, new EventArgs ());

			}
		}
	}
}

