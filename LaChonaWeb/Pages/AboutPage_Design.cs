using System;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;

namespace LaChonaWeb
{
	public partial class AboutPage : ContentPage
	{
		Image LogoImage{ get; set;}
		Label TitleLabel { get;set;}
		Label InfoLabel { get;set;}
		CircleImage FacebookImage { get; set;}
		CircleImage TwitterImage { get; set;}
		CircleImage PinterestImage { get; set;}
		CircleImage WebPageImage { get; set;}

		public void Layout ()
		{
			this.Title = "La Chona Web";
			LogoImage = new Image ();
			LogoImage.Source = "demo_picture.jpg";
			LogoImage.VerticalOptions = LayoutOptions.Start;
			LogoImage.HorizontalOptions = LayoutOptions.FillAndExpand;

			TitleLabel = new Label ();
			TitleLabel.Text = "La Chona Web"; 
			TitleLabel.FontAttributes = FontAttributes.Bold;
			TitleLabel.FontSize = 22;
			TitleLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;

			InfoLabel = new Label ();
			InfoLabel.Text = "Visita nuestras redes sociales y nuestra pagina para revisar noticias, fotos, vídeos etc.";
			InfoLabel.FontAttributes = FontAttributes.Bold;
			InfoLabel.FontSize = 17;
			InfoLabel.HorizontalTextAlignment = TextAlignment.Start;
			InfoLabel.HorizontalOptions = LayoutOptions.StartAndExpand;

			var infoLayout = new StackLayout ();
			infoLayout.Spacing = 20;
			infoLayout.Padding = new Thickness (10,0);
			infoLayout.Children.Add (TitleLabel);
			infoLayout.Children.Add (InfoLabel);

			FacebookImage = new CircleImage ();
			FacebookImage.HeightRequest = 60;
			FacebookImage.WidthRequest = 60;
			FacebookImage.Source = "ic_facebook";
			TapGestureRecognizer tapFacebookIcon = new TapGestureRecognizer ();
			FacebookImage.GestureRecognizers.Add (tapFacebookIcon);
			tapFacebookIcon.Tapped += (object sender, EventArgs e) => {
				Device.OpenUri (new Uri ("https://www.facebook.com/lachonaweb/"));
			};


			TwitterImage = new CircleImage ();
			TwitterImage.HeightRequest = 60;
			TwitterImage.WidthRequest = 60;
			TwitterImage.Source = "ic_twitter";
			TapGestureRecognizer tapTwitterIcon = new TapGestureRecognizer ();
			TwitterImage.GestureRecognizers.Add (tapTwitterIcon);
			tapTwitterIcon.Tapped += (object sender, EventArgs e) => {
				Device.OpenUri (new Uri ("https://www.twitter.com/@lachonaweb"));
			};

			PinterestImage = new CircleImage ();
			PinterestImage.HeightRequest = 60;
			PinterestImage.WidthRequest = 60;
			PinterestImage.Source = "ic_pinterest";
			TapGestureRecognizer tapPinterestIcon = new TapGestureRecognizer ();
			PinterestImage.GestureRecognizers.Add (tapPinterestIcon);
			tapPinterestIcon.Tapped += (object sender, EventArgs e) => {
				Device.OpenUri (new Uri ("https://www.pinterest.com/lachonaweb"));
			};

			WebPageImage = new CircleImage ();
			WebPageImage.HeightRequest = 60;
			WebPageImage.WidthRequest = 60;
			WebPageImage.Source = "ic_page";
			TapGestureRecognizer tapWebPageIcon = new TapGestureRecognizer ();
			WebPageImage.GestureRecognizers.Add (tapWebPageIcon);
			tapWebPageIcon.Tapped += (object sender, EventArgs e) => {
				Device.OpenUri (new Uri ("http://lachonaweb.com/wp/"));
			};

			var iconsLayout = new StackLayout ();
			iconsLayout.Children.Add (FacebookImage);
			iconsLayout.Children.Add (TwitterImage);
			iconsLayout.Children.Add (PinterestImage);
			iconsLayout.Children.Add (WebPageImage);
			iconsLayout.Spacing = 10;
			iconsLayout.Padding = new Thickness (0, 0, 0, 10);
			iconsLayout.Orientation = StackOrientation.Horizontal;
			iconsLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
			iconsLayout.VerticalOptions = LayoutOptions.EndAndExpand;

			var contentLayout = new StackLayout ();
			contentLayout.Children.Add (LogoImage);
			contentLayout.Children.Add (infoLayout);
			contentLayout.Children.Add (iconsLayout);

			Content = contentLayout;

		}
	}
}

