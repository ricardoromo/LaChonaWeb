using System;
using Xamarin.Forms;

namespace LaChonaWeb
{
	public partial class FeedsPage : ContentPage
	{
		public ListView FeedsListView { get; set;}
		public ActivityIndicator LoadFeedIndicator{ get; set;}
		public void Layout ()
		{
			FeedsListView = new ListView ();
			FeedsListView.HasUnevenRows = true;
			FeedsListView.IsPullToRefreshEnabled = true;
			FeedsListView.ItemTemplate = new DataTemplate (typeof(FeedsCell));
			FeedsListView.SeparatorColor = Color.FromHex("E53935");
			FeedsListView.SetBinding (ListView.ItemsSourceProperty, "FeedsList");
			FeedsListView.SetBinding(ListView.RefreshCommandProperty,"LoadItemsCommand");
			FeedsListView.SetBinding(ListView.IsRefreshingProperty, new Binding("IsBusy",BindingMode.OneWay));

			LoadFeedIndicator = new ActivityIndicator ();
			Device.OnPlatform (
				Android: () => {
					LoadFeedIndicator.SetBinding (ActivityIndicator.IsRunningProperty, "IsBusy");
				});
			LoadFeedIndicator.HorizontalOptions = LayoutOptions.CenterAndExpand;
			LoadFeedIndicator.VerticalOptions = LayoutOptions.CenterAndExpand;

			Grid contentGrid = new Grid ();
			contentGrid.Children.Add (FeedsListView, 0, 0);
			contentGrid.Children.Add (LoadFeedIndicator, 0, 0);

			Content = contentGrid;
		}

	}
}

