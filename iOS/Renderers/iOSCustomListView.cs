using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using LaChonaWeb;
using LaChonaWeb.iOS.Renderer;

[assembly:ExportRenderer(typeof(CustomListView), typeof(iOSCustomListView))]
namespace LaChonaWeb.iOS.Renderer
{
	public class iOSCustomListView : ListViewRenderer
	{
		public iOSCustomListView ()
		{
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

		}

		protected override void OnElementChanged (ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged (e);
			if (Element != null) {
				var element = (CustomListView)Element;
				this.Control.ScrollEnabled = element.ScrollEnabled;
			}
		}
	}
}

