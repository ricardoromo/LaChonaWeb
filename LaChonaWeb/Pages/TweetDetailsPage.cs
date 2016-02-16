using System;
using Xamarin.Forms;

namespace LaChonaWeb
{
	public class TweetDetailsPage : ContentPage
	{
		public string Site { get; set;}
		public TweetDetailsPage (string site)
		{
			this.Title = "La Chona Web";
			Site = site;
			this.SizeChanged += TweetDetailsPage_SizeChanged;
		}

		public void TweetDetailsPage_SizeChanged (object sender, EventArgs e)
		{
			Layout ();
		}

		CustomWebView webView { get; set;}
		public void Layout()
		{
			var webView = new CustomWebView ();
			webView.Source = Site;
			webView.ControlWidth = this.Width;
			webView.ControlHeight = this.Height;
			webView.VerticalOptions = LayoutOptions.FillAndExpand;
			webView.HorizontalOptions = LayoutOptions.FillAndExpand;
			Content = webView;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			this.SizeChanged += TweetDetailsPage_SizeChanged;
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			this.SizeChanged -= TweetDetailsPage_SizeChanged;
		}
	}
}

