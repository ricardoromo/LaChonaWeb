using System;
using Xamarin.Forms;

namespace LaChonaWeb
{
	public class CustomWebView : ContentView
	{
		public CustomWebView ()
		{
		}

		private static readonly BindableProperty SourceProperty =
			BindableProperty.Create<CustomWebView, string> ( p=>p.Source, string.Empty);

		public string Source { 
			get { return (string)GetValue (SourceProperty); }
			set { SetValue (SourceProperty, value); }
		}

		private static readonly BindableProperty LoadPageFinishedProperty =
			BindableProperty.Create<CustomWebView, bool> ( p=>p.LoadPageFinished, false);

		public bool LoadPageFinished { 
			get { return (bool)GetValue (LoadPageFinishedProperty); }
			set { SetValue (LoadPageFinishedProperty, value); }
		}

		private static readonly BindableProperty LoadPageStartedProperty =
			BindableProperty.Create<CustomWebView, bool> ( p=>p.LoadPageStarted, false);

		public bool LoadPageStarted { 
			get { return (bool)GetValue (LoadPageStartedProperty); }
			set { SetValue (LoadPageStartedProperty, value); }
		}

		private static readonly BindableProperty LoadPageFailedProperty =
			BindableProperty.Create<CustomWebView, bool> ( p=>p.LoadPageFailed, false);

		public bool LoadPageFailed { 
			get { return (bool)GetValue (LoadPageFailedProperty); }
			set { SetValue (LoadPageFailedProperty, value); }
		}

		private static readonly BindableProperty ControlWidthProperty =
			BindableProperty.Create<CustomWebView, double> ( p=>p.ControlWidth, 0);

		public double ControlWidth { 
			get { return (double)GetValue (ControlWidthProperty); }
			set { SetValue (ControlWidthProperty, value); }
		}

		private static readonly BindableProperty ControlHeightProperty =
			BindableProperty.Create<CustomWebView, double> ( p=>p.ControlHeight, 0);

		public double ControlHeight { 
			get { return (double)GetValue (ControlHeightProperty); }
			set { SetValue (ControlHeightProperty, value); }
		}


		public event EventHandler OnLoadCompleted;
		public void LoadCompleted(object sender, EventArgs e)
		{
			if (OnLoadCompleted != null) {
				OnLoadCompleted (sender,e);
			}
		}

		public event EventHandler OnLoadStarted;
		public void LoadStarted(object sender, EventArgs e)
		{
			if (OnLoadStarted != null) {
				OnLoadStarted (sender,e);
			}
		}

		public event EventHandler OnLoadFailed;
		public void LoadFailed(object sender, EventArgs e)
		{
			if (OnLoadFailed != null) {
				OnLoadFailed (sender,e);
			}
		}
	}
}

