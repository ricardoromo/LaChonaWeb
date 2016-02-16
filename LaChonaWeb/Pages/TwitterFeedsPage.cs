using System;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace LaChonaWeb
{
	public partial class TwitterFeedsPage : ContentPage
	{

		private TwitterViewModel TwitterViewModel
		{
			get { return BindingContext as TwitterViewModel; }
		}


		public TwitterFeedsPage ()
		{
			this.Title = "La Chona Web";
			BindingContext = new TwitterViewModel(new TweetModel());
			Layout ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			TweetsListView.ItemTapped += TweetsListView_ItemTapped;
			if (TwitterViewModel == null || TwitterViewModel.Tweets.Count > 0)
				return;
			if (CrossConnectivity.Current.IsConnected)
				TwitterViewModel.LoadTweetsCommand.Execute(null);
			else
				DisplayAlert ("Error de conexion", "Revisa tu conexion a internet", "Aceptar");
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			TweetsListView.ItemTapped -= TweetsListView_ItemTapped;
		}
		public void TweetsListView_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			if ((sender as ListView).SelectedItem == null)
				return;
			(sender as ListView).SelectedItem = null;

			var tweet = e.Item as TweetModel;
			Navigation.PushAsync (new TweetDetailsPage ("http://m.twitter.com/lachonaweb/status/" + tweet.StatusID),true);
		}
	}
}

