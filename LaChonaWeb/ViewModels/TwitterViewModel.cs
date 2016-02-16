using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using LinqToTwitter;
using System.Threading.Tasks;
using System.Linq;
using Plugin.Connectivity;


namespace LaChonaWeb
{
	public class TwitterViewModel : BaseViewModel
	{
		public ObservableCollection<TweetModel> Tweets { get; set; }

		TweetModel TweetModelM;

		public TwitterViewModel (TweetModel tweetModelM)
		{
			TweetModelM = tweetModelM;
			Tweets = new ObservableCollection<TweetModel> ();
		}

		private bool isBusy;
		public bool IsBusy {
			get {
				return isBusy; 
			}
			set {
				isBusy = value;
				OnPropertyChanged (nameof(IsBusy));
			}
		}

		private Command loadTweetsCommand;

		public Command LoadTweetsCommand {
			get {
				return loadTweetsCommand ??
				(loadTweetsCommand = new Command (async () => {
					await ExecuteLoadTweetsCommand ();
				}, () => {
					return !IsBusy;
				}));
			}
		}

		public async Task ExecuteLoadTweetsCommand ()
		{
			if (!CrossConnectivity.Current.IsConnected){
				IsBusy = false;
				return;
			}

			if (IsBusy)
				return;

			IsBusy = true;
			Tweets.Clear ();
			var auth = new ApplicationOnlyAuthorizer () {
				CredentialStore = new InMemoryCredentialStore {
					ConsumerKey = Constants.ConsumerKey,
					ConsumerSecret = Constants.ConsumerSecret,
				},
			};
			await auth.AuthorizeAsync ();

			var twitterContext = new TwitterContext (auth);

			var queryResponse = await (from tweet in twitterContext.Status
			  where tweet.Type == StatusType.User &&
			      tweet.ScreenName == "lachonaweb" &&
			      tweet.Count == 100 &&
			      tweet.IncludeRetweets == true &&
				  tweet.ExcludeReplies == true 
			  select tweet).ToListAsync ();

			var tweets =
				(from tweet in queryResponse
				 select new TweetModel {
					StatusID = tweet.StatusID,
					ScreenName = tweet.User.ScreenNameResponse,
					Text = tweet.Text,
					CurrentUserRetweet = tweet.CurrentUserRetweet,
					CreatedAt = tweet.CreatedAt,
					Image = tweet.RetweetedStatus != null && tweet.RetweetedStatus.User != null ?
							tweet.RetweetedStatus.User.ProfileImageUrl.Replace ("normal", "bigger") : (tweet.User.ScreenNameResponse == "lachonaweb" ? Constants.AppLogo : tweet.User.ProfileImageUrl.Replace ("normal", "bigger")),
				}).ToList ();
			foreach (var tweet in tweets) {
				
				Tweets.Add (tweet);
			}
			IsBusy = false;
			LoadTweetsCommand.ChangeCanExecute ();
		}
	}
}

