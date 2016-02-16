using System;
using Xamarin.Forms;

namespace LaChonaWeb
{
	public class CustomListView : ListView
	{


		public CustomListView ()
		{
		}

		public static readonly BindableProperty ScrollEnabledProperty =
			BindableProperty.Create<CustomListView, bool> ( p=>p.ScrollEnabled, true);

		public bool ScrollEnabled { 
			get { return (bool)GetValue (ScrollEnabledProperty); }
			set { SetValue (ScrollEnabledProperty, value); }
		}
	}
}

