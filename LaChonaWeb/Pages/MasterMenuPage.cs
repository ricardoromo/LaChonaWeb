using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Plugin.Connectivity;

namespace LaChonaWeb
{
	public partial class MasterMenuPage : ContentPage
	{
		List<MenuItemsViewModel> MenuItemsList { get; set;} = new List<MenuItemsViewModel>()
		{
			new MenuItemsViewModel(){Title = "Noticias",IconSource="rss_circle_gray.png", TargetType = typeof(FeedsPage)},
			new MenuItemsViewModel(){Title = "Twitter",IconSource="twitter_circle_gray.png",TargetType = typeof(TwitterFeedsPage)},
			new MenuItemsViewModel(){Title = "About",IconSource="info_outline.png",TargetType = typeof(AboutPage)}	
		};

		public MasterMenuPage ()
		{
			Layout ();
		}
	}
}

