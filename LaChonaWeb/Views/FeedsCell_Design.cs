using System;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;

namespace LaChonaWeb
{
	public partial class FeedsCell : ViewCell
	{
		public Label TitleLabel { get; set;}
		public Label DescriptionLabel { get; set;}
		public Label PublishDateLabel { get; set;}
		public Label CategoryLabel { get; set; }
		public Label AutorLabel { get; set; }
		public CircleImage LogoImage{ get; set;}

		public void Layout ()
		{
			LogoImage = new CircleImage ();
			LogoImage.VerticalOptions = LayoutOptions.CenterAndExpand;
			LogoImage.HeightRequest = 50;
			LogoImage.WidthRequest = 50;
			LogoImage.BorderThickness = 1;
			LogoImage.BorderColor = Color.White;
			LogoImage.Aspect = Aspect.AspectFit;
			LogoImage.VerticalOptions = LayoutOptions.CenterAndExpand;
			LogoImage.SetBinding (Image.SourceProperty, "LogoSource");

			TitleLabel = new Label();
			TitleLabel.FontSize = 20;
			TitleLabel.FontAttributes = FontAttributes.Bold;
			TitleLabel.SetBinding (Label.TextProperty, "Title");

			DescriptionLabel = new Label();
			DescriptionLabel.SetBinding (Label.TextProperty, "Description");

			PublishDateLabel  =  new Label();
			PublishDateLabel.FontSize = 10;
			PublishDateLabel.SetBinding (Label.TextProperty, "PublishDate");

			CategoryLabel = new Label();
			CategoryLabel.SetBinding (Label.TextProperty, "Category");

			AutorLabel = new Label();
			AutorLabel.FontSize = 10;
			AutorLabel.SetBinding (Label.TextProperty, "Autor");

			var detailsLayout = new StackLayout ();
			detailsLayout.Children.Add (AutorLabel);
			detailsLayout.Children.Add (PublishDateLabel);
			detailsLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
			detailsLayout.Orientation = StackOrientation.Horizontal;

			var contentLayout = new StackLayout ();
			contentLayout.Children.Add (TitleLabel);
			contentLayout.Children.Add (detailsLayout);

			var viewLayout = new StackLayout ();
			viewLayout.Spacing = 10;
			viewLayout.Children.Add (LogoImage);
			viewLayout.Children.Add (contentLayout);
			viewLayout.Orientation = StackOrientation.Horizontal;
			viewLayout.Padding = new Thickness (5, 5);

			View = viewLayout;
		}
	}
}

