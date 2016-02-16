using System;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace LaChonaWeb
{
	public partial class FeedsPage : ContentPage
	{

		private FeedsViewModel FeedsViewModel{get { return BindingContext as FeedsViewModel; }}

		public FeedsPage ()
		{
			this.Title = "La Chona Web";
			BindingContext = new FeedsViewModel(new FeedsModel());
			Layout ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			FeedsListView.ItemTapped += FeedsListView_ItemTapped;

			if (FeedsViewModel == null || FeedsViewModel.IsBusy || FeedsViewModel.FeedsList.Count > 0)
				return;
			
			if (CrossConnectivity.Current.IsConnected)
				FeedsViewModel.LoadItemsCommand.Execute (null);
			else
				DisplayAlert ("Error de conexion", "Revisa tu conexion a internet", "Aceptar");
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			FeedsListView.ItemTapped -= FeedsListView_ItemTapped;
		}


		private void FeedsListView_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			if ((sender as ListView).SelectedItem == null)
				return;
			(sender as ListView).SelectedItem = null;
			var feed = e.Item as FeedsModel;
			Navigation.PushAsync(new FeedDetailsPage(feed));
		}
	}
}

