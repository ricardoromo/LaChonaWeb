using System;
using Xamarin.Forms;

namespace LaChonaWeb
{
	public class FeedDetailsPage : ContentPage
	{
		FeedsModel Feed;
		public FeedDetailsPage (FeedsModel feed)
		{
			this.Title = feed.Title;
			Feed = feed;
			this.SizeChanged += FeedDetailsPage_SizeChanged;
		}

		void FeedDetailsPage_SizeChanged (object sender, EventArgs e)
		{
			Layout ();
		}

		CustomWebView webView { get; set;}
		public void Layout()
		{
			var webView = new CustomWebView ();
			webView.Source = Feed.Link;
			webView.ControlWidth = this.Width;
			webView.ControlHeight = this.Height;
			webView.VerticalOptions = LayoutOptions.FillAndExpand;
			webView.HorizontalOptions = LayoutOptions.FillAndExpand;
			Content = webView;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			this.SizeChanged -= FeedDetailsPage_SizeChanged;
		}
	}
}

