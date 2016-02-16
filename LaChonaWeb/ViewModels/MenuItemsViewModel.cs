using System;
using Xamarin.Forms;

namespace LaChonaWeb
{
	public class MenuItemsViewModel : BaseViewModel
	{
		public MenuItemsViewModel ()
		{
		}

		private string title{ get; set;}
		public string Title {
			get{
				return title;
			}set{
				title = value;
				OnPropertyChanged(nameof(Title));
			}
		}

		private string iconSource {get; set;}
		public string IconSource {
			get{
				return iconSource;
			}set{
				iconSource = value;
				OnPropertyChanged(nameof(IconSource));
			}
		}

		private Color textColor {get; set;}
		public Color TextColor {
			get{
				if (IsSelected)
					return Color.FromHex("E53935");
				return Color.Black;
					
			}
		}

		private bool isSelected{ get; set;}
		public bool IsSelected {
			get{
				return isSelected;
			}set{
				isSelected = value;
				OnPropertyChanged(nameof(IsSelected));
				OnPropertyChanged(nameof(TextColor));
			}
		}

		private Type targetType{ get; set;}
		public Type TargetType { 
			get
			{
				return targetType;
			}
			set{ targetType = value;
			}
		}
	}
}

