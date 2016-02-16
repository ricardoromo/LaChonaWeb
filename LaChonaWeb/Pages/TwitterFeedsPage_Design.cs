using System;
using Xamarin.Forms;

namespace LaChonaWeb
{
	public partial class TwitterFeedsPage : ContentPage
	{
		public ListView TweetsListView { get; set;}
		public ActivityIndicator LoadFeedIndicator{ get; set;}

		public void Layout ()
		{
			TweetsListView = new ListView ();
			TweetsListView.HasUnevenRows = true;
			TweetsListView.IsPullToRefreshEnabled = true;
			TweetsListView.ItemTemplate = new DataTemplate(typeof(TweetCell));
			TweetsListView.SetBinding(ListView.ItemsSourceProperty,"Tweets");
			TweetsListView.SeparatorColor = Color.FromHex("E53935");
			TweetsListView.SetBinding(ListView.RefreshCommandProperty,"LoadTweetsCommand");
			TweetsListView.SetBinding(ListView.IsRefreshingProperty, new Binding("IsBusy",BindingMode.OneWay));

			LoadFeedIndicator = new ActivityIndicator ();
			Device.OnPlatform (
				Android: () => {
					LoadFeedIndicator.SetBinding (ActivityIndicator.IsRunningProperty, "IsBusy");
				});
			LoadFeedIndicator.HorizontalOptions = LayoutOptions.CenterAndExpand;
			LoadFeedIndicator.VerticalOptions = LayoutOptions.CenterAndExpand;

			Grid contentGrid = new Grid ();
			contentGrid.Children.Add (TweetsListView, 0, 0);
			contentGrid.Children.Add (LoadFeedIndicator, 0, 0);

			Content = contentGrid;
		}
	}
}

