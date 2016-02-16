using System;
using Xamarin.Forms;
using System.Linq;

namespace LaChonaWeb
{
	public class HomeScreenPage : MasterDetailPage
	{
		public MasterMenuPage MasterMenuPage { get; set; }
		public MenuItemsViewModel CurrentItem { get; set; }

		public HomeScreenPage ()
		{
			this.Title = "La Chona Web";

			MasterMenuPage = new MasterMenuPage {Icon = "ic_menu_white.png", Title = "Menu" };
			CurrentItem = MasterMenuPage.MenuItemsListView.ItemsSource.Cast<MenuItemsViewModel> ().FirstOrDefault ();
			CurrentItem.IsSelected = true;
			MasterMenuPage.MenuItemsListView.SelectedItem = CurrentItem;
			if(MasterMenuPage.MenuItemsListView.SelectedItem != null)
				MasterMenuPage.MenuItemsListView.SelectedItem  = null;

			Master = MasterMenuPage;

			Detail = new NavigationPage(new FeedsPage()){
				BarBackgroundColor = Color.FromHex("E53935"),
				BarTextColor = Color.White
			};
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MasterMenuPage.MenuItemsListView.ItemSelected += MenuOptionSelected;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			MasterMenuPage.MenuItemsListView.ItemSelected -= MenuOptionSelected;
		}

		protected void MenuOptionSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if ((sender as ListView).SelectedItem == null)
				return;
			(sender as ListView).SelectedItem = null;
			NavigateTo(e.SelectedItem as MenuItemsViewModel);
		}


		void NavigateTo (MenuItemsViewModel menu){

			if (CurrentItem != null) {
				if (CurrentItem.Title == menu.Title) {
					IsPresented = false;
					return;
				}
				CurrentItem.IsSelected = false;
			}

			CurrentItem = menu;
			CurrentItem.IsSelected = true;

			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);

			Detail = new NavigationPage (displayPage){ 
				BarBackgroundColor = Color.FromHex("E53935"),
				BarTextColor = Color.White
			};

			IsPresented = false;
		}
	}
}

