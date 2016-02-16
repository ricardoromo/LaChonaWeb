using System;
using Xamarin.Forms;

namespace LaChonaWeb
{
	public partial class MenuCell : ViewCell
	{
		public Image DetailImage { get; set;}
		public Label Title { get; set;}
		public void Layout ()
		{
			DetailImage = new Image ();
			DetailImage.HeightRequest = 40;
			DetailImage.WidthRequest = 40;
			DetailImage.SetBinding(Image.SourceProperty,"IconSource");
			DetailImage.VerticalOptions = LayoutOptions.CenterAndExpand;

			Title = new Label ();
			Title.FontSize = 20;
			Title.FontAttributes = FontAttributes.Bold;
			Title.SetBinding(Label.TextProperty,"Title");
			Title.SetBinding(Label.TextColorProperty,"TextColor");
			Title.VerticalOptions = LayoutOptions.CenterAndExpand;
			var contentLayout = new StackLayout ();
			contentLayout.Orientation = StackOrientation.Horizontal;
			contentLayout.Children.Add (DetailImage);
			contentLayout.Children.Add (Title);
			contentLayout.Padding = new Thickness (5,0);
			contentLayout.Spacing = 10;
			View = contentLayout;

		}
	}
}

