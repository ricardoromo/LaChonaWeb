using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using LaChonaWeb;
using LaChonaWeb.iOS.Renderer;
using UIKit;
using System.ComponentModel;
using Foundation;
using CoreGraphics;

[assembly : ExportRenderer(typeof(CustomWebView),typeof(iOSCustomWebView))]
namespace LaChonaWeb.iOS.Renderer
{
	public class iOSCustomWebView : ViewRenderer<CustomWebView, UIView>
	{
		CustomWebView CustomWebView { get; set;}
		UIActivityIndicatorView ActiveIndicator { get; set;} 
		UIWebView webView { get; set;}
		public iOSCustomWebView ()
		{
			

		}

		protected override void OnElementChanged (ElementChangedEventArgs<CustomWebView> e)
		{
			base.OnElementChanged (e);

			if (Element != null) {
				CustomWebView = (CustomWebView)Element;
				UIView contentView = new UIView (this.Frame);

				ActiveIndicator = new UIActivityIndicatorView (new CGRect((double)((CustomWebView.ControlWidth/ 2) - 25),(double)((CustomWebView.ControlHeight / 2)- 25),50,50));
				ActiveIndicator.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray;

				webView = new UIWebView (new CGRect(0,0,(double)(CustomWebView.ControlWidth),(double)(CustomWebView.ControlHeight)));
				webView.LoadFinished += WebView_LoadFinished;
				webView.LoadStarted += WebView_LoadStarted;
				webView.LoadError += WebView_LoadError;
				webView.ScalesPageToFit = true;


				var url = CustomWebView.Source; // NOTE: https secure request
				webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));

				contentView.AddSubview (webView);
				contentView.AddSubview (ActiveIndicator);
				SetNativeControl(contentView);
			}
		}

		protected override void OnElementPropertyChanged (object sender, PropertyChangedEventArgs e)
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


		//Hack to avoid call several times LoadError event.
		private bool Failed = false;
		void WebView_LoadError (object sender, UIWebErrorArgs e)
		{
			if (!Failed) {
				Failed = true;
				ActiveIndicator.StopAnimating ();
				CustomWebView.LoadPageFailed = true;
			}
		}

		//Hack to avoid call several times LoadFinished event.
		private bool Finished = false;
		void WebView_LoadFinished (object sender, EventArgs e)
		{
			if (!Finished) {
				Finished = true;
				ActiveIndicator.StopAnimating ();
				CustomWebView.LoadPageFinished = true;
			}
		}

		//Hack to avoid call several times LoadStart event.
		private bool Loaded = false;
		void WebView_LoadStarted (object sender, EventArgs e)
		{
			if (!Loaded) {
				Loaded = true;
				ActiveIndicator.StartAnimating ();
				CustomWebView.LoadPageStarted = true;
			}
		}
	}
}

