using System;
using Xamarin.Forms;
using System.Xml.Linq;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Plugin.Connectivity;

namespace LaChonaWeb
{
	public class FeedsViewModel : BaseViewModel
	{
		

		public FeedsModel FeedsModelM;
		public FeedsViewModel (FeedsModel feedsModelM)
		{
			FeedsModelM = feedsModelM;
		}
			

		private bool isBusy;
		public bool IsBusy {
			get {
				return isBusy; 
			}
			set {
				isBusy = value;
				OnPropertyChanged (nameof (IsBusy));
			}
		}

		public string Title { 
			get{
				return FeedsModelM.Title;
			} 
			set{ 
				value = FeedsModelM.Title;
			} 
		}

		public string PublishDate { 
			get{
				return FeedsModelM.PublishDate;
			} 
			set{ 
				value = FeedsModelM.PublishDate;
			} 
		}

		public string Description { 
			get{
				return FeedsModelM.Description;
			} 
			set{ 
				value = FeedsModelM.Description;
			} 
		}

		public string Category { 
			get{
				return FeedsModelM.Category;
			} 
			set{ 
				value = FeedsModelM.Category;
			} 
		}

		public string Autor { 
			get{
				return FeedsModelM.Autor;
			} 
			set{ 
				value = FeedsModelM.Autor;
			} 
		}

		private ObservableCollection<FeedsModel> feedsList= new ObservableCollection<FeedsModel>();
		public ObservableCollection<FeedsModel> FeedsList {
			get { return feedsList; }
			set {
				feedsList = value;
				OnPropertyChanged (nameof (FeedsList));
			}
		}


		private Command loadItemsCommand { get; set;}
		public Command LoadItemsCommand {
			get { 
				return loadItemsCommand ?? (loadItemsCommand = new Command (async () => 
					await ExecuteLoadItemsCommand (),
					() => {
						return !IsBusy;
					}));
			}
		}

		private async Task ExecuteLoadItemsCommand ()
		{
			if (!CrossConnectivity.Current.IsConnected) {
				IsBusy = false;
				return;
			}

			if (IsBusy)
				return;

			IsBusy = true;
			var xmlFeed = string.Empty;
			List<FeedsModel> items = new List<FeedsModel> ();
			using (var httpClient = new HttpClient ()) {
				var rssFeed = "http://lachonaweb.com/wp/?feed=rss2";
				xmlFeed = await httpClient.GetStringAsync (rssFeed);
				var xdoc = XDocument.Parse (xmlFeed);
				XNamespace dc = "http://purl.org/dc/elements/1.1/";
				await Task.Run (() => {
					items = (from item in xdoc.Descendants ("item")
							select new FeedsModel() {
						Title = item.Element ("title").Value,
						Description = item.Element ("description").Value,
						Link = item.Element ("link").Value,
						PublishDate = item.Element ("pubDate").Value,
						Category = item.Element ("category").Value,
						Autor = item.Element (dc + "creator").Value
					}).ToList ();
				});

			}
	
			FeedsList.Clear ();
			foreach (var item in items) {
				FeedsList.Add (item);
			}

			IsBusy = false;
		}
	}
}

