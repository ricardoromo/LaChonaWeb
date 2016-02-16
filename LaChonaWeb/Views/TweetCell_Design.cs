using System;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;

namespace LaChonaWeb
{
	public partial class TweetCell : ViewCell
	{
		CircleImage ProfileImage{ get; set;}
		Label TweetDateLabel{ get; set;}
		Label TweetLabel { get; set;}

		public void Layout ()
		{
			ProfileImage = new CircleImage ();
			ProfileImage.HeightRequest = 60;
			ProfileImage.WidthRequest = 60;
			ProfileImage.SetBinding (Image.SourceProperty, "Image");
			ProfileImage.BorderThickness = 1;
			ProfileImage.BorderColor = Color.FromHex("E53935");
			ProfileImage.Aspect = Aspect.AspectFit;
			ProfileImage.VerticalOptions = LayoutOptions.StartAndExpand;

			TweetLabel = new Label ();
			TweetLabel.SetBinding (Label.TextProperty,"Text");

			TweetDateLabel = new Label ();
			TweetDateLabel.SetBinding (Label.TextProperty,"Date");

			var contentLayout = new StackLayout ();
			contentLayout.Children.Add (TweetLabel);
			contentLayout.Children.Add (TweetDateLabel);

			var viewLayout = new StackLayout ();
			viewLayout.Spacing = 3;
			viewLayout.Children.Add (ProfileImage);
			viewLayout.Children.Add (contentLayout);
			viewLayout.Orientation = StackOrientation.Horizontal;
			viewLayout.Padding = new Thickness (5, 5);

			View = viewLayout;
		}
	}
}

