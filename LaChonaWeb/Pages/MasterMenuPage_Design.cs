using System;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;

namespace LaChonaWeb
{
	public partial class MasterMenuPage : ContentPage
	{
		public CustomListView MenuItemsListView { get; set;}
		public CircleImage LogoImage { get; set;}
		public void Layout ()
		{

			LogoImage = new CircleImage ();
			LogoImage.HorizontalOptions = LayoutOptions.CenterAndExpand;
			LogoImage.HeightRequest = 200;
			LogoImage.WidthRequest = 200;
			LogoImage.Source = "https://pbs.twimg.com/profile_images/516999224429654016/0_8IV3Rd.jpeg";
			LogoImage.BorderThickness = 1;
			LogoImage.BorderColor = Color.Transparent;
			LogoImage.Aspect = Aspect.AspectFit;

			MenuItemsListView = new CustomListView ();
			MenuItemsListView.ScrollEnabled = false;
			MenuItemsListView.ItemsSource = MenuItemsList;
			MenuItemsListView.HeightRequest = 135;
			MenuItemsListView.SeparatorColor = Color.FromHex("E53935");
			MenuItemsListView.BackgroundColor = Color.Transparent;
			MenuItemsListView.VerticalOptions = LayoutOptions.StartAndExpand;
			MenuItemsListView.ItemTemplate = new DataTemplate(typeof(MenuCell));

			var contenLayout = new StackLayout ();
			contenLayout.Padding = new Thickness (0, 40);
			contenLayout.Children.Add (LogoImage);
			contenLayout.Children.Add (MenuItemsListView);
			contenLayout.BackgroundColor = Color.White;
			Content = contenLayout;
		}
	}
}

